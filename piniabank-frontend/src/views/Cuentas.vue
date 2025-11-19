<script setup>
import { AccountService } from '@/service/AccountService';

import { useToast } from 'primevue/usetoast';
import { onMounted, ref, watch } from 'vue';
import { useRoute } from 'vue-router';
const route = useRoute();
const cuentas = ref();

const loading = ref(false);
const toast = useToast();

onMounted(async () => {
  await consultarCuentas(route.params.idCliente);
});

watch(
  () => route.params.idCliente,
  (newId, oldId) => {
    consultarCuentas(newId);
  }
);

// onMounted(() => {
//   CustomerService.getData().then((data) => (clientes.value = data));
// });

/**
 * Crea la cuenta al cliente
 */
async function consultarCuentas(idCliente) {
  loading.value = true; // 1. activar loading
  try {
    const res = await AccountService.consultarCuentas(idCliente);
    console.log('res--->', res);

    if (!res.ok) throw new Error('Error al crear la cuenta'); // 2. validar respuesta

    const data = await res.json();
    console.log('data--->', data);

    cuentas.value = data;
  } catch (err) {
    toast.add({
      // 6. notificar error
      severity: 'error',
      summary: 'Error',
      detail: err.message || 'No se pudo crear la cuenta',
      life: 3000
    });
  } finally {
    loading.value = false; // 7. siempre apagar loading
  }
}
</script>
<template>
  <div className="card">
    <DataTable
      :value="cuentas"
      :paginator="true"
      :rows="10"
      :loading="loading"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
      :rowsPerPageOptions="[5, 10, 25]"
      currentPageReportTemplate="Mostrando {first} a {last} of {totalRecords} clientes"
    >
      <template #header>
        <div class="flex flex-wrap gap-2 items-center justify-between">
          <h4 class="m-0">Cuentas del cliente</h4>
        </div>
      </template>
      <Column field="numero" header="Número" sortable style="min-width: 12rem"></Column>
      <Column field="tipo" header="Tipo" sortable style="min-width: 16rem"></Column>
      <Column field="estado" header="Estado" sortable style="min-width: 16rem"></Column>
      <Column field="saldo" header="Saldo" sortable style="min-width: 16rem"></Column>
      <!-- <Column>
        <template #body="{ data }">
          <Button label="Agregar cuenta" icon="pi pi-plus" text @click="mostrarFormCrearCuenta(data.id)" rounded severity="info" />
        </template>
      </Column> -->
    </DataTable>
  </div>
</template>
