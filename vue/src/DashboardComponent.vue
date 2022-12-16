<template>
  <div class="dashboard">
    <div class="row mb-4">
      <div class="col-sm">
        <h2>
          <span class="small text-uppercase text-muted d-block"
            >Screw Monitoring</span
          >
          <!-- {{ rangeStart.toDateString() }} - {{ today.toDateString() }} -->
        </h2>
        Last screw id:
      </div>
      <div class="col-sm text-sm-end">
        {{ currentTime }}
        <!-- <ButtonGroup :index="selectedIndex">
          <KButton @click="onSelect(1)">Days</KButton>
          <KButton @click="onSelect(2)">Weeks</KButton>
          <KButton @click="onSelect(3)">Month</KButton>
        </ButtonGroup> -->
      </div>
    </div>
    <div class="row k-card-list">
      <div
        :class="[
          'col-md-12',
          currentScreenWidth >= 1150 ? 'k-card-deck' : 'k-card-list',
        ]"
      >
        <div :class="[currentScreenWidth >= 1150 ? 'col-md-auto' : '']">
          <Card>
            <CardHeader :class="'h4'">Status</CardHeader>
            <CardBody>
              <span class="comp-label">
                <strong style="color: green">OK</strong>
              </span>
            </CardBody>
          </Card>
        </div>
        <div :class="[currentScreenWidth >= 1150 ? 'col-md-auto' : '']">
          <Card>
            <CardHeader :class="'h4'">Torque</CardHeader>
            <CardBody>
              <span class="comp-label">
                <strong>13 Nm</strong>
              </span>
            </CardBody>
          </Card>
        </div>
      </div>
      <div class="col-md-auto">
        <Card>
          <CardHeader :class="'h3'">Statistics</CardHeader>
          <CardBody>
            <Suspense>
              <BatchListVue />
            </Suspense>
          </CardBody>
        </Card>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue';
import { Button as KButton, ButtonGroup } from '@progress/kendo-vue-buttons';
import {
  Chart,
  ChartArea,
  ChartSeries,
  ChartSeriesItem,
  ChartCategoryAxis,
  ChartCategoryAxisItem,
  ChartValueAxis,
  ChartValueAxisItem,
  ChartSeriesDefaults,
  ChartCategoryAxisLabels,
  ChartLegend,
} from '@progress/kendo-vue-charts';
import { Card, CardHeader, CardBody } from '@progress/kendo-vue-layout';
import 'hammerjs';
import BatchListVue from './components/BatchList.vue';

window.onresize = () => {
  currentScreenWidth.value = window.innerWidth;
};

const currentTime = ref(new Date().toLocaleString());
const updateTime = () => {
  currentTime.value = new Date().toLocaleString();
};
setInterval(updateTime, 1000);
const currentScreenWidth = ref(1150);
const today = new Date();
const selectedIndex = ref(0);
const days = computed(() => {
  switch (selectedIndex.value) {
    case 0:
      return 7;
    case 1:
      return 14;
    case 2:
      return 30;
    default:
      return 3;
  }
});
const rangeStart = computed(() => {
  const since = new Date();
  since.setDate(since.getDate() - days.value);
  return since;
});
const onSelect = (ev: number) => {
  selectedIndex.value = ev;
};
</script>
