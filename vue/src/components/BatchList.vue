<script setup lang="ts">
import { ref } from 'vue';
import batch, { type Batch } from '../services/batch';
import { Grid } from '@progress/kendo-vue-grid';
const batches = ref<Batch[]>((await batch.getAll()).data);
const clolumns = [
  { field: 'batchId' },
  { field: 'startTs' },
  { field: 'endTs' },
  { field: 'note' },
];
</script>

<template>
  <Grid
    :data-items="batches"
    :columns="clolumns"
    ref="grid"
    style="width: 440px"
  />
</template>

<style scoped></style>
