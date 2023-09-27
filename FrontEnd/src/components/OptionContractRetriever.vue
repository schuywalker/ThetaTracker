<script setup lang="ts">
    import axios from 'axios';
    import { ref, onMounted } from 'vue';
    const fetchedData = ref<string | null>('');
    const fetchedContracts = ref<string | null>('');

    onMounted(async () => {
        try {
            const response = await axios.get('http://localhost:5147/WeatherForecast')
            fetchedData.value = response.data;
        }  catch (error) {
            console.error('Test1 onMounted error: ', error);
        }
    }
    )

    async function fetchContracts(): Promise<void>  {
        try {
            const response = await axios.get('http://localhost:5147/WeatherForecast')
            fetchedContracts.value = response.data;
        }  catch (error) {
            console.error('Test1 onMounted error: ', error);
        }
    }
</script>

<template>
    <p class="fetchedData">{{fetchedData}}</p>
    <div>
        <button @click="fetchContracts">click me</button>
        <p class="fetchedContracts">{{fetchedContracts}}</p>
    </div>
    </template>