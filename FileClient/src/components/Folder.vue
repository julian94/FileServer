<script setup lang="ts">
import type { FolderItem } from "../File";
defineProps<{
  folder: FolderItem;
}>();
</script>

<template>
  <div class="folder">
    <h1 class="green">{{ folder.Name }}</h1>
    <li v-for="item in folder.Folders">{{ item.Name }}</li>
    <li v-for="item in folder.Files">{{ item.Name }}</li>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  top: -10px;
}
</style>
