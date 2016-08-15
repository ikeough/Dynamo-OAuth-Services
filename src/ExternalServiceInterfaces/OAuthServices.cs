﻿using System.Collections.Generic;

namespace ExternalServiceInterfaces
{
    /// <summary>
    /// OAuthServices is a singleton which is backed by a collection of IOAuthServices.
    /// </summary>
    public class OAuthServices : IExternalServices<IExternalService>
    {
        private static OAuthServices instance;
        private Dictionary<string, IExternalService> services = new Dictionary<string, IExternalService>();
         
        public static OAuthServices Instance
        {
            get
            {
                instance = instance ?? new OAuthServices();
                return instance;
            }
        }

        private OAuthServices()
        {
            
        }

        public IEnumerable<IExternalService> Services
        {
            get { return services.Values; }
        }

        public void AddService(IExternalService service)
        {
            if (!services.ContainsKey(service.Name))
            {
                services.Add(service.Name, service);
            }
        }

        public void RemoveService(IExternalService service)
        {
            if (services.ContainsKey(service.Name))
            {
                services.Remove(service.Name);
            }
        }

        public IExternalService GetServiceByName(string serviceName)
        {
            return services.ContainsKey(serviceName) ? services[serviceName] : null;
        }
    }
}
