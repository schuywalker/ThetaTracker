from datetime import date, datetime
from yahooquery import Ticker
import pandas as pd
import pymongo
import re

stocks = ['AAPL','AI','AMC','GME','PLTR','SPY','TSLA','DISH','RIOT','GLD']



myclient = pymongo.MongoClient("mongodb://localhost:27017/")
mydb = myclient['option_chains']

for stock in stocks:
    ticker = Ticker(stock)
    data = ticker.option_chain
    df = pd.DataFrame(data)
    

    timestampCreated = int(datetime.now().timestamp())
    dayCreated = date.today().strftime('%b_%d_%Y')
    print(stock, ' dayCreated: ', dayCreated) 


    
    collection = mydb[stock]


    for i in range(len(df)):
        temp = df.iloc[i]['contractSymbol']
        match = re.match(r'([A-Z]+)(\d+)([A-Z]+)(\d+)', temp, re.I)
        if match:
            ticker, expDate, cp, number = match.groups()
            expirationDate = datetime.strptime(expDate, '%y%m%d')
            cp = cp

            # print(f'Ticker: {ticker}\nDate: {int(expirationDate.timestamp())}\ncp: {cp}')
        else:
            raise Exception(f'Regex match unsuccessful: {temp}')
        
        
        document = {'dayCreated': dayCreated,
                    'createdTS':timestampCreated, 
                    'contractSymbol': df['contractSymbol'][i], 
                    'ticker': ticker,
                    'expirationDateTS': int(expirationDate.timestamp()),
                    'cp': cp,
                    'strike': df['strike'][i], 
                    'currency': df['currency'][i], 
                    'lastPrice': df['lastPrice'][i], 
                    'change': df['change'][i], 
                    'percentChange': df['percentChange'][i], 
                    'volume': df['volume'][i], 
                    'openInterest': float(df['openInterest'][i]), 
                    'bid': df['bid'][i], 
                    'ask': df['ask'][i], 
                    'contractSize': df['contractSize'][i], 
                    'lastTradeDate': int(df['lastTradeDate'][i].timestamp()),
                    'impliedVolatility':"{:.8f}".format(df['impliedVolatility'][i]), 
                    'inTheMoney': bool(df['inTheMoney'][i])
                    }

        collection.insert_one(document)
        



