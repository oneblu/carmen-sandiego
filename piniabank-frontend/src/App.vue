<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer">
      <v-sheet class="pa-4" color="grey-lighten-4">
        <v-avatar class="mb-4" color="grey-darken-1" size="64"></v-avatar>

        <div>john@google.com</div>
      </v-sheet>

      <v-divider></v-divider>

      <v-list>
        <v-list-item
          v-for="[icon, text] in links"
          :key="icon"
          :prepend-icon="icon"
          :title="text"
          link
        ></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <v-app-bar-title>Mi Banco <v-icon icon="mdi-home" /></v-app-bar-title>
    </v-app-bar>

    <v-main>

        <RouterView />

    </v-main>
  </v-app>
</template>

<script setup>
import { ref } from 'vue'

const links = [
  ['mdi-inbox-arrow-down', 'Inbox'],
  ['mdi-send', 'Send'],
  ['mdi-delete', 'Trash'],
  ['mdi-alert-octagon', 'Spam'],
]

const drawer = ref(null)
</script>

<script>
export default {
  data: () => ({
    cards: ['Today', 'Yesterday'],
    drawer: null,
    links: [
      ['mdi-inbox-arrow-down', 'Inbox'],
      ['mdi-send', 'Send'],
      ['mdi-delete', 'Trash'],
      ['mdi-alert-octagon', 'Spam'],
    ],
  }),
}
</script>
