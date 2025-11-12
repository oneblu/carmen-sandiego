<!-- eslint-disable vue/multi-word-component-names -->
<template>
    <v-card class="mx-auto" max-width="500" flat>
        <v-list-item class="px-6" height="88">
            <template v-slot:prepend>
                <v-avatar color="surface-light" size="32">🎯</v-avatar>
            </template>
            <template v-slot:title>Clientes</template>
            <template v-slot:append>
                <v-btn class="text-none" color="primary" text="Crear cliente" variant="text" slim></v-btn>
            </template>
        </v-list-item>

        <v-divider></v-divider>

        <v-table>
            <thead>
                <tr>
                    <th class="text-left">Nombres</th>
                    <th class="text-left">Apellidos</th>
                    <th>Acción</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in clientes" :key="item.id">
                    <td>{{ item.nombres }}</td>
                    <td>{{ item.apellidos }}</td>
                    <td><v-btn append-icon="mdi-pencil" color="primary">Editar</v-btn></td>
                </tr>
            </tbody>
        </v-table>
    </v-card>
</template>

<script setup>
import { ref, onMounted } from 'vue'

var clientes = ref(null)

async function fetchData() {
    try {
        const response = await fetch('https://localhost:44308/Clientes')

        if (!response.ok) {
            throw new Error('Error HTTP: ' + response.status)
        }

        const data = await response.json()
        clientes.value = data
        console.log(data)

        return data
    } catch (error) {
        console.error('Error al obtener datos:', error)
    }
}

onMounted(() => {
    fetchData()
})
</script>
