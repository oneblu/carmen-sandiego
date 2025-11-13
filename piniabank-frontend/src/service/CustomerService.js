export const CustomerService = {
  getData() {
    return fetch('https://localhost:44308/Clientes').then((res) => res.json());
  },

  guardar(cliente) {
    return fetch('https://localhost:44308/Clientes', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(cliente)
    });
  },

  getCustomersSmall() {
    return Promise.resolve(this.getData().slice(0, 10));
  },

  getCustomersMedium() {
    return Promise.resolve(this.getData().slice(0, 50));
  },

  getCustomersLarge() {
    return Promise.resolve(this.getData().slice(0, 200));
  },

  getCustomersXLarge() {
    return Promise.resolve(this.getData());
  },

  getCustomers(params) {
    const queryParams = params
      ? Object.keys(params)
          .map((k) => encodeURIComponent(k) + '=' + encodeURIComponent(params[k]))
          .join('&')
      : '';

    return fetch('https://localhost:44308/Clientes?' + queryParams).then((res) => res.json());
  }
};
