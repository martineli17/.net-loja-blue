# API referente a um contexto de loja.
### Observações:
- A API foi implementada na tecnologia .NET 5. Sendo assim, é necessário ter o SDK do mesmo instalado na sua máquina.
- Para persistência dos dados, foi utilizado o SQL Server e o Redis (para armazenar os produtos).

### Utilização:
- Primeiro, é necessário cadastrar o seu usuário.
- Posteriormente, realizar o login para que, assim, obtenha o token JWT de acesso e consiga realizar as demais operações
- Necessário cadastrar os produtos que terá na loja.
- Iniciar um carrinho com algum item.
- Pode inserir novos produtos, atualizar ou remover do carrinho.
- Finalizar a compra, informando as credenciais do usuário.

### Configurações
- Necessário inserir o seu servidor do SQL Server, no campo 'SqlServer'.
- Necessário inserir o seu servidor do Redis, no campo 'RedisSettings'.

Abaixo, segue o appSettings.json de configuração.

`
{

  "Logging": {
  
    "LogLevel": {
    
      "Default": "Information",
      
      "Microsoft": "Warning",
      
      "Microsoft.Hosting.Lifetime": "Information"
      
    }
    
  },
  
  "ConnectionStrings": {
  
    "SqlServer": "Server=SEU_SERVIDOR;Database=Loja;User Id=SEU_USUARIO;Password=SUA_SENHA;"
    
  },
  
  "AppSettings": {
  
    "Expiration": 1,
    
    "Issuer": "MyApplication",
    
    "Audience": "https://localhost",
    
    "SecretKey": "fabiomartinelisecretapplication"
    
  },
  
  "RedisSettings": {
  
    "Password": null,
    
    "AllowAdmin": true,
    
    "Ssl": false,
    
    "ConnectTimeout": 6000,
    
    "ConnectRetry": 2,
    
    "Database": 1,
    
    "KeyPrefix": "Loja",
    
    "Hosts": [
    
      {
      
        "Host": "localhost",
        
        "Port": "6379"
        
      }
      
    ]
    
  },
  
  "AllowedHosts": "*"
  
}

`
