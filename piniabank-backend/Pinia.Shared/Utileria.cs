namespace Pinia.Shared
{
    public static class Utileria
    {
        public static string GenerarNumeroCuenta()
        {
            // Usar Random.Shared que es thread-safe
            return Random.Shared.Next(100000000, 1000000000).ToString("D9");
        }

        // Versión que retorna long en lugar de string
        public static long GenerarNumeroCuentaLong()
        {
            return Random.Shared.Next(100000000, 1000000000);
        }
    }
}
