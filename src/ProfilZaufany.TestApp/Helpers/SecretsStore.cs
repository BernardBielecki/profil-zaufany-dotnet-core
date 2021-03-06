﻿using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using ProfilZaufany.X509;

namespace ProfilZaufany.TestApp.Helpers
{
    /// <summary>
    /// W środowisku produkcyjnym certyfikat powinien znajdować się w bezpiecznym magazynie
    /// </summary>
    public class SecretsStore : ISecretsStore, IX509Provider
    {
        private X509Certificate2 _certificate2;
        private string _samlIssuer;

        public X509Certificate2 GetCertificate()
        {
            return _certificate2;
        }

        public void SetCertificate(X509Certificate2 certificate2)
        {
            _certificate2 = certificate2;
        }

        public string GetSamlIssuer()
        {
            return _samlIssuer;
        }

        public void SetSamlIssuer(string issuer)
        {
            _samlIssuer = issuer;
        }

        public Task<X509Certificate2> Provide(CancellationToken token)
        {
            return Task.FromResult(_certificate2);
        }
    }
}