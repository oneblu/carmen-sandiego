<script setup>
import { AccountService } from '@/service/AccountService';

import { useToast } from 'primevue/usetoast';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
const route = useRoute();
const cuentas = ref();
const saldo = ref(0);
const mostrarDialogCrearTransaccion = ref(false);
const loading = ref(false);
const toast = useToast();

const tiposTransaccion = ref(['Consignacion', 'Retiro']);
const transaccion = ref({
  tipo: '',
  idCuenta: '',
  valor: 0
});

onMounted(async () => {
  await consultarCuentas(route.params.idCliente);
});

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

async function agregarTransaccion() {
  loading.value = true; // 1. activar loading
  try {
    const res = await AccountService.agregarTransaccion(transaccion.value);
    console.log('res--->', res);

    if (!res.ok) throw new Error('Error al crear la transaccion'); // 2. validar respuesta

    toast.add({
      // 3. notificar éxito
      severity: 'success',
      summary: 'Successful',
      detail: 'La transaccion ha sido creada',
      life: 3000
    });
    cancelarTransaccion();
    await consultarCuentas(route.params.idCliente);
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

function mostrarFormulario(idCuenta, saldoActual) {
  console.log('saldo-->', saldoActual);
  saldo.value = saldoActual;
  transaccion.value.tipo = '';
  transaccion.value.valor = 0;
  transaccion.value.idCuenta = idCuenta;
  mostrarDialogCrearTransaccion.value = true;
}

function cancelarTransaccion() {
  saldo.value = 0;
  mostrarDialogCrearTransaccion.value = false;
}
function moneda(valor) {
  return new Intl.NumberFormat('es-CO', { style: 'currency', currency: 'COP' }).format(valor);
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
      <Column field="saldo" header="Saldo" sortable style="min-width: 16rem">
        <template #body="{ data }">
          {{ moneda(data.saldo) }}
        </template>
      </Column>

      <Column field="estado" header="Estado" dataType="boolean" bodyClass="text-center" style="min-width: 8rem">
        <template #body="{ data }">
          <i v-tooltip="'Estado de la cuenta ' + (data.estado ? 'Activa' : 'Inactiva')" class="pi" :class="{ 'pi-check-circle text-green-500 ': data.estado, 'pi-times-circle text-red-500': !data.estado }"></i>
        </template>
      </Column>
      <Column>
        <template #body="{ data }">
          <Button label="Crear transaccion" icon="pi pi-plus" text @click="mostrarFormulario(data.id, data.saldo)" rounded severity="info" />
        </template>
      </Column>
    </DataTable>

    <Dialog v-model:visible="mostrarDialogCrearTransaccion" :style="{ width: '450px' }" header="Crear nueva transaccion" :modal="true">
      <div class="flex flex-col gap-6">
        <div>
          <Message severity="info" icon="pi pi-money-bill">Saldo actual: {{ moneda(saldo) }}</Message>
        </div>
        <div>
          <label for="name" class="block font-bold mb-3">Tipo de transaccion</label>
          <SelectButton v-model="transaccion.tipo" :options="tiposTransaccion" fluid />
        </div>
        <div>
          <label for="name" class="block font-bold mb-3">Valor</label>
          <InputText id="name" v-model.trim="transaccion.valor" required="true" autofocus fluid />
          <Message class="mt-4" severity="error" icon="pi pi-exclamation-triangle" v-if="transaccion.valor > saldo && transaccion.tipo === 'Retiro'">Fondos insuficientes!</Message>
        </div>
      </div>

      <template #footer>
        <Button label="Cancelar" icon="pi pi-times" text @click="cancelarTransaccion" />
        <Button label="Crear transaccion" icon="pi pi-check" :disabled="transaccion.valor > saldo && transaccion.tipo === 'Retiro'" :loading="loading" @click="agregarTransaccion" />
      </template>
    </Dialog>
  </div>
</template>
