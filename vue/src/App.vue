<script setup lang="ts">
import BatchListVue from './components/BatchList.vue';
</script>

<template>
  <div>
    <Suspense>
      <BatchListVue />
    </Suspense>
  </div>
</template>

<style scoped></style>
