<script setup>
import router from '@/router';
import { AccountService } from '@/service/AccountService';
import { CustomerService } from '@/service/CustomerService';
import { useToast } from 'primevue/usetoast';
import { onMounted, ref } from 'vue';

const clientes = ref();
const cliente = ref({});
const mostrarDialog = ref(false);

const mostrarDialogCrearCuenta = ref(false);

const tiposDeCuenta = ref([
  { name: 'Ahorros', code: 'Ahorros' },
  { name: 'Corriente', code: 'Corriente' }
]);

const loading = ref(false);

const nuevaCuenta = ref({
  tipo: '',
  idCliente: ''
});

const toast = useToast();

onMounted(async () => {
  await consultarClientes();
});

async function consultarClientes() {
  loading.value = true; // 1. activar loading
  try {
    const res = await CustomerService.consultarClientes();
    console.log('res-->', res);
    if (!res.ok) throw new Error('Error consultando los clientes'); // 2. validar respuesta
    clientes.value = await res.json();
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

function openNew() {
  cliente.value = {};
  mostrarDialog.value = true;
}

function guardar() {
  CustomerService.guardar(cliente.value);
  toast.add({ severity: 'success', summary: 'Successful', detail: 'Cliente Created', life: 3000 });
  mostrarDialog.value = false;
  cliente.value = {};
}
function hideDialog() {
  mostrarDialog.value = false;
}

function mostrarFormCrearCuenta(idCliente) {
  mostrarDialogCrearCuenta.value = true;
  nuevaCuenta.value.idCliente = idCliente;
}
function cancelarCrearCuenta() {
  mostrarDialogCrearCuenta.value = false;
  nuevaCuenta.value.idCliente = '';
  nuevaCuenta.value.tipo = '';
}

function verCuentas(idCliente) {
  router.push({ path: `/cuentas/${idCliente}` });
}

/**
 * Crea la cuenta al cliente
 */
async function guardarNuevaCuenta() {
  loading.value = true; // 1. activar loading
  try {
    const res = await AccountService.guardar(nuevaCuenta.value);

    if (!res.ok) throw new Error('Error al crear la cuenta'); // 2. validar respuesta

    console.log('crear cuenta--->', res);
    const numeroCuenta = await res.text();

    toast.add({
      // 3. notificar éxito
      severity: 'success',
      summary: 'Successful',
      detail: 'La cuenta ha sido creada ' + numeroCuenta,
      life: 5000
    });
    mostrarDialogCrearCuenta.value = false; // 4. cerrar modal
    // 5. limpiar formulario
    nuevaCuenta.value.idCliente = '';
    nuevaCuenta.value.tipo = '';
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
    <Toolbar class="mb-6">
      <template #start>
        <Button label="New" icon="pi pi-plus" severity="secondary" class="mr-2" @click="openNew" />
      </template>
    </Toolbar>
    <DataTable
      :value="clientes"
      :paginator="true"
      :rows="10"
      :loading="loading"
      paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
      :rowsPerPageOptions="[5, 10, 25]"
      currentPageReportTemplate="Mostrando {first} a {last} of {totalRecords} clientes"
    >
      <template #header>
        <div class="flex flex-wrap gap-2 items-center justify-between">
          <h4 class="m-0">Clientes del banco</h4>
        </div>
      </template>
      <Column field="nombres" header="Nombres" sortable style="min-width: 12rem"></Column>
      <Column field="apellidos" header="Apellidos" sortable style="min-width: 16rem"></Column>
      <Column>
        <template #body="{ data }">
          <Button label="Ver cuentas" icon="pi pi-eye" text @click="verCuentas(data.id)" rounded severity="info" />
        </template>
      </Column>
      <Column>
        <template #body="{ data }">
          <Button label="Agregar cuenta" icon="pi pi-plus" text @click="mostrarFormCrearCuenta(data.id)" rounded severity="info" />
        </template>
      </Column>
    </DataTable>

    <Dialog v-model:visible="mostrarDialog" :style="{ width: '450px' }" header="Crear cliente" :modal="true">
      <div class="flex flex-col gap-6">
        <div>
          <label for="name" class="block font-bold mb-3">Nombres</label>
          <InputText id="name" v-model.trim="cliente.nombres" required="true" autofocus :invalid="submitted && !product.name" fluid />
          <small v-if="submitted && !product.name" class="text-red-500">Name is required.</small>
        </div>
        <div>
          <label for="name" class="block font-bold mb-3">Apellidos</label>
          <InputText id="name" v-model.trim="cliente.apellidos" required="true" autofocus :invalid="submitted && !product.name" fluid />
          <small v-if="submitted && !product.name" class="text-red-500">Name is required.</small>
        </div>
        <div>
          <label for="name" class="block font-bold mb-3">No. de Identificacion</label>
          <InputText id="name" v-model.trim="cliente.numeroIdentificacion" required="true" autofocus :invalid="submitted && !product.name" fluid />
          <small v-if="submitted && !product.name" class="text-red-500">Name is required.</small>
        </div>
      </div>

      <template #footer>
        <Button label="Cancel" icon="pi pi-times" text @click="hideDialog" />
        <Button label="Save" icon="pi pi-check" @click="guardar" />
      </template>
    </Dialog>

    <Dialog v-model:visible="mostrarDialogCrearCuenta" :style="{ width: '450px' }" header="Crear nueva cuenta" :modal="true">
      <div class="flex flex-col gap-6">
        <div>
          <label for="name" class="block font-bold mb-3">Tipo de cuenta</label>
          <Select fluid v-model="nuevaCuenta.tipo" :options="tiposDeCuenta" optionValue="code" optionLabel="name" placeholder="Selecciona el tipo de cuenta" class="w-full md:w-56" />
        </div>
      </div>

      <template #footer>
        <Button label="Cancelar" icon="pi pi-times" text @click="cancelarCrearCuenta" />
        <Button label="Crear cuenta" icon="pi pi-check" :loading="loading" @click="guardarNuevaCuenta" />
      </template>
    </Dialog>
  </div>
</template>
