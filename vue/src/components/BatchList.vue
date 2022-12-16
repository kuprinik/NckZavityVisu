<script setup lang="ts">
import { ref } from 'vue';
import batch, { type Batch } from '../services/batch';
import { Grid } from '@progress/kendo-vue-grid';
const batches = ref<Batch[]>((await batch.getAll()).data);
const clolumns = [
  { field: 'batchId', title: 'ID' },
  { field: 'note', title: 'Status' },
  { field: 'note', title: 'Torque' },
  { field: 'startTs', title: 'Start' },
  { field: 'endTs', title: 'End' },
];
</script>

<template>
  <Grid :data-items="batches" :columns="clolumns" ref="grid" />
</template>

<style scoped></style>
