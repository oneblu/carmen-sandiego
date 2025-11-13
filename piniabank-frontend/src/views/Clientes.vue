<script setup>
import { CustomerService } from '@/service/CustomerService';
import { useToast } from 'primevue/usetoast';
import { onMounted, ref } from 'vue';
const clientes = ref();
const cliente = ref({});
const mostrarDialog = ref(false);
const toast = useToast();

const fecha = ref(null);

onMounted(() => {
  CustomerService.getData().then((data) => (clientes.value = data));
});

function openNew() {
  cliente.value = {};
  mostrarDialog.value = true;
}

function alerta(algo) {
  alert(algo);
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
    </DataTable>

    <Dialog v-model:visible="mostrarDialog" :style="{ width: '450px' }" header="Product Details" :modal="true">
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
  </div>
</template>
