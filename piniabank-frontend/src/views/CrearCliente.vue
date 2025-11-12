<template>
  <v-sheet class="mx-auto" width="300">
    <v-form>
      <v-text-field v-model="nombres" label="Nombres"></v-text-field>
      <v-text-field v-model="apellidos" label="Apellidos"></v-text-field>
      <v-text-field v-model="numeroIdentificacion" label="Numero de identificacion"></v-text-field>
      <v-btn @click="createCliente">Crear</v-btn>

    </v-form>
  </v-sheet>
</template>

<script setup>
import { ref } from 'vue'

const nombres = ref('')
const apellidos = ref('')
const numeroIdentificacion = ref('')

async function createCliente() {
  const data = {
    nombres: nombres.value,
    apellidos: apellidos.value,
    numeroIdentificacion: numeroIdentificacion.value
  };

  try {
    const response = await fetch('https://localhost:44308/Clientes', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    });

    const result = await response.json();
    console.log('Respuesta:', result);
  } catch (error) {
    console.error('Error:', error);
  }
}

</script>
