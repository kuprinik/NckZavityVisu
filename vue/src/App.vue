<script setup lang="ts">
import BatchListVue from './components/BatchList.vue';
import { AppBar } from '@progress/kendo-vue-layout';
import DashboardComponentVue from './DashboardComponent.vue';
import { DrawerContent } from '@progress/kendo-vue-layout';
</script>

<template>
  <link
    rel="stylesheet"
    href="https://kendo.cdn.telerik.com/themes/5.10.0/default/default-ocean-blue.css"
  />
  <div id="app" class="app">
    <DrawerContent>
      <DashboardComponentVue />
    </DrawerContent>
  </div>
  <!-- <AppBar>
    <AppBarSpacer :width="8" />
    <AppBarSection>
      <h1 :class="'title'">Screw Monitoring</h1>
    </AppBarSection>
  </AppBar>
  <div style="display: flex; flex-direction: horizontal; margin: 2%">
    <div class="brdr"></div>
    <div class="brdr"></div>
  </div>
  <div class="brdr">
    <Suspense>
      <BatchListVue style="margin: 2%" />
    </Suspense>
  </div> -->
</template>

<style scoped>
#app {
  padding: 0 !important;
}
.title {
  font-size: 18px;
  margin: 0;
}
.social-section .k-icon {
  margin: 0 4px;
}
ul {
  font-size: 12px;
  list-style-type: none;
  padding: 0;
  margin: 0;
  display: flex;
}
li {
  margin: 0 12px;
}
li:hover {
  cursor: pointer;
  color: #ccc;
}
.page-content {
  height: 90%;
  background: white;
  padding: 20px 10px;
}

.k-button.k-button-md.k-rounded-md.k-button-flat.k-button-flat-base {
  padding: 0;
}

.brdr {
  border: 2px solid #006100;
  border-radius: 10px;
}
</style>
