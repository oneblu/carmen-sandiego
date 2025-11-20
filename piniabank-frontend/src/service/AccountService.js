export const AccountService = {
  guardar(cuenta) {
    return fetch('https://localhost:44308/Cuentas', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(cuenta)
    });
  },

  consultarCuentas(idCliente) {
    return fetch('https://localhost:44308/Cuentas?idCliente=' + idCliente);
  },
  agregarTransaccion(transaccion) {
    return fetch('https://localhost:44308/Cuentas/transacciones', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(transaccion)
    });
  }
};
