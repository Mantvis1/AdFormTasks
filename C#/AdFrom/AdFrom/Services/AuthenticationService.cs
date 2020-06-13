using AdFrom.Services.Interfaces;
using System.Threading.Tasks;

namespace AdFrom.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<string> GetToken()
        {
           return "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Imh1ZXFCazVjLWVtNDFUQXFicnhlZGdpMExHWSIsImtpZCI6Imh1ZXFCazVjLWVtNDFUQXFicnhlZGdpMExHWSJ9.eyJpc3MiOiJodHRwczovL2lkLmFkZm9ybS5jb20vc3RzIiwiYXVkIjoiaHR0cHM6Ly9pZC5hZGZvcm0uY29tL3N0cy9yZXNvdXJjZXMiLCJleHAiOjE1OTIwODI4NDksIm5iZiI6MTU5MjA3OTI0OSwiY2xpZW50X2lkIjoicHVibGlzaGVyc3RhdHMucHVibGljQGFkZm9ybS5jb20iLCJzdWIiOiJjZmI1MDk0Ny0wMDc4LTQ3NmMtOTk5My1mMDBmM2VmNzU2OGEiLCJzY29wZSI6Imh0dHBzOi8vYXBpLmFkZm9ybS5jb20vc2NvcGUvZWFwaSJ9.udvZe0nFHbILcU71wHDE8csGV6zPiM1AealFl - h8pr0kSyYGlzQKbpHnzZe6DM - AejPoRXFAo5GVmOa2nrauQOVuPE_H0G1BUFTPh - mhPfBCvNKlNw710cUyfIStP00ISLBJIaq6wu_hhL9DrBRiJr1XmjN_7uT7eK9NAqrZ0S - G2ge7KhLxQzBrLjqyqsy07zgZJ8NZoQlempmUVccF5NxliCBKePXsXh7wxL2APERz1zRJdbkYXjL2nNwx_tzN67ZwmMXC_jbmX7ENQIiav72N_h1U925HhWqHCpLRI__vYViitUGD27Kv00NFAJl0wG_P - GY5cuim2hRLdXqH2A";
        }
    }
}
