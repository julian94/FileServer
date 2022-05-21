<script setup lang="ts">
import Folder from "../Components/Folder.vue";
</script>

<template>
  <div class="files">
    <h1>This is a list of files.</h1>
    <Folder ></Folder>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
