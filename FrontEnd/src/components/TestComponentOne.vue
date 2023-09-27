<script setup lang="ts">
    import axios from 'axios';
    import { ref, onMounted } from 'vue';
    const fetchedData = ref<string | null>(null);

    onMounted(async () => {
        try {
            const response = await axios.get('http://localhost:5147/WeatherForecast')
            fetchedData.value = response.data;
        }  catch (error) {
            console.error('Test1 onMounted error: ', error);
        }
    }
    )
</script>

<template>
    <p class="fetchedData">{{fetchedData}}</p>
</template>