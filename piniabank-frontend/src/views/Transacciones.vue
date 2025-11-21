<script setup>
import { AccountService } from '@/service/AccountService';
import { format } from 'date-fns';
import { useToast } from 'primevue/usetoast';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
const route = useRoute();
const loading = ref(false);
const toast = useToast();
const transacciones = ref();

onMounted(async () => {
  await getTransacciones(route.params.idCuenta);
});

/**
 * Crea la cuenta al cliente
 */
async function getTransacciones(idCuenta) {
  loading.value = true; // 1. activar loading
  try {
    const res = await AccountService.consultarTransacciones(idCuenta);
    console.log('res--->', res);

    if (!res.ok) throw new Error('Error al crear la cuenta'); // 2. validar respuesta
    const data = await res.json();
    transacciones.value = data;
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

function moneda(valor) {
  return new Intl.NumberFormat('es-CO', { style: 'currency', currency: 'COP' }).format(valor);
}

function formatoFecha(fecha) {
  return format(fecha, 'dd/MM/yyyy H:mm');
}
</script>
<template>
  <div className="card">
    <DataTable
      :value="transacciones"
      :paginator="true"
      :rows="10"
      :loading="loading"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
      :rowsPerPageOptions="[5, 10, 25]"
      currentPageReportTemplate="Mostrando {first} a {last} of {totalRecords} clientes"
    >
      <template #header>
        <div class="flex flex-wrap gap-2 items-center justify-between">
          <h4 class="m-0">Transacciones bancarias</h4>
        </div>
      </template>
      <Column field="id" header="ID" sortable style="min-width: 12rem"></Column>
      <Column field="tipo" header="Tipo" sortable style="min-width: 16rem"></Column>
      <Column field="valor" header="Valor" sortable style="min-width: 16rem">
        <template #body="{ data }">
          <span :class="{ 'text-green-500 ': data.tipo === 'Consignacion' || data.tipo === 'deposito', 'text-red-500': data.tipo === 'Retiro' || data.tipo === 'retiro' }">
            {{ moneda(data.valor) }}
          </span>
        </template>
      </Column>
      <Column field="fechaDeCreacion" header="Fecha" sortable style="min-width: 16rem">
        <template #body="{ data }">
          {{ formatoFecha(data.fechaDeCreacion) }}
        </template>
      </Column>
      <Column field="estado" header="Estado" dataType="boolean" bodyClass="text-center" style="min-width: 8rem">
        <template #body="{ data }">
          <span :class="{ 'text-green-500 ': data.estado, 'text-red-500': !data.estado }">
            {{ !data.estado ? 'Anulada' : '' }}
          </span>
        </template>
      </Column>
    </DataTable>
  </div>
</template>
