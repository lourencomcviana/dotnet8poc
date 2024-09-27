## Padrão de solução

### Subprojetos

- Business
-  somente 1 projeto
- Infraestructure (api, banco, buckent, socket, SOAP)
- vários projetos, um para cada conector
- Interface (controller, UI, cmd)
- vários projetos, dependendo do tipo de UX
- Domain (interfaces, entidades)


[![](https://mermaid.ink/img/pako:eNp1kM1qwzAQhF9F7EmF5AVcKNhxC4Xm0h6rHDbW2hatVkI_hxDy7pFRDCklt_1GM4N2zzA4TdDAFNDP4uNTsRAxHyv2zqLhRRKil5Wenhcm1or_eLscDVOM1d3JlR_533kMGFPIQ8qBamonO-dSEdHXmBCvco_eG55W4U3uybpwWvhRc6Iw4nArbWXrzZpuv9Gbg9huX8Tun9Ld9cEGLIWysC7HOS8PCtJMlhQ0ZdQYfhQovhQf5uS-TjxAU7ahDQSXpxmaEX9joew1JuoNls_Zm3q5Aqf_ecQ?type=png)](https://mermaid.live/edit#pako:eNp1kM1qwzAQhF9F7EmF5AVcKNhxC4Xm0h6rHDbW2hatVkI_hxDy7pFRDCklt_1GM4N2zzA4TdDAFNDP4uNTsRAxHyv2zqLhRRKil5Wenhcm1or_eLscDVOM1d3JlR_533kMGFPIQ8qBamonO-dSEdHXmBCvco_eG55W4U3uybpwWvhRc6Iw4nArbWXrzZpuv9Gbg9huX8Tun9Ld9cEGLIWysC7HOS8PCtJMlhQ0ZdQYfhQovhQf5uS-TjxAU7ahDQSXpxmaEX9joew1JuoNls_Zm3q5Aqf_ecQ)
``` mermaid
flowchart TD
    Domain <--> Business
    Domain <--> Interface
    Domain <--> Infraestructures
    Business --> Infraestructures
    Infraestructures --> Business
```

## Nomenclatura

### Solução
`{{sigla}}-{{squad}}-{{project-name}}-{{project-type}}`

### Projetos

{{project-name}}.{{group-type}}.{{integration-type}}
{{project-name}}.{{group-type}}.{{integration-type}}.{{project-reference}}


Quando único:

{{project-name}}.{{group-type}}


exemplos:
- antecipacao.interface.api
- antecipacao.interface.cmd
- antecipacao.domain
- antecipacao.business
- antecipacao.infraestructure.dynamo
- antecipacao.infraestructure.cxone

## Estrutura de pastas
```
qv-ivr-antecipacao-api 🌳
| -- business 💼
|    \ -- antecipacao.business 📈
| -- domain 🌐
|    \ -- antecipacao.domain 📂
| -- infra 🏗️
|    | -- antecipacao.infra.bootstrap 🚀
|    | -- antecipacao.infra.mapping 🗺️
|    | -- proxy 🌉
|    |    | -- antecipacao.infra.proxy.cxone 🌐
|    |    \ -- antecipacao.infra.proxy.zenit 🌟
|    | -- repository 📦
|    |    | -- antecipacao.infra.repository.dynamo 🧬
|    |    | -- antecipacao.infra.repository.redis 🧠
|    |    \ -- antecipacao.infra.repository.bucket🗑️
|    \ -- socket 🔌
|         \ -- antecipacao.infra.socket.ge ⚡
| -- interface 🖥️
|     | -- antecipacao.interface.api 🌐
|     \ -- antecipacao.interface.cmd ⌨️
\ -- test 🧪
     | -- unit 🔍
     \ -- integrated 🔗
```

- scaffolding
- commit-lint


## Lambda

### Consumo api
`{{sigla}}-{{squad}}-{{project-name}}-{{consumed-api}}-lambda`
```
qv-ivr-antecipacao-cxone-lambda
| -- antecipacao.lambda
|    | -- proxy
|    |    | -- request.cs
|    |    | -- response.cs
|    |    \ -- client.cs
|    | -- domain
|    |    | -- antecipacao.cs
|    |    | -- mapping.cs
|    |    \ -- validation.cs
|    \ -- FunctionHandler.cs (método FunctionHandler)
\ -- test
     \ -- unit
```

## Scheduling

`{{sigla}}-{{squad}}-{{project-name}}-scheduler-lambda`

```
qv-ivr-antecipacao-scheduler-lambda
| -- antecipacao.lambda
|    | -- proxy
|    |    | -- request.cs
|    |    | -- response.cs
|    |    \ -- client.cs
|    | -- main.cs
\ -- test
     \ -- unit
```

## Solution creation
``` bash
dotnet new sln -n sigla-squad-myapp-api
dotnet new classlib -n myapp.business -o business/myapp.business
dotnet new classlib -n myapp.domain -o domain/myapp.domain
dotnet new classlib -n myapp.infra.bootstrap -o infra/myapp.infra.bootstrap
dotnet new classlib -n myapp.infra.mapping -o infra/myapp.infra.mapping
dotnet new classlib -n myapp.infra.repository.memory -o infra/repository/myapp.infra.repository.memory
dotnet new webapi -n myapp.interface.api -o interface/myapp.interface.api
dotnet new xunit -n unit -o test/unit


dotnet sln add business/myapp.business/myapp.business.csproj dotnet sln add domain/myapp.domain/myapp.domain.csproj
dotnet sln add infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj 
dotnet sln add infra/myapp.infra.mapping/myapp.infra.mapping.csproj 
dotnet sln add infra/repository/myapp.infra.repository.memory/myapp.infra.repository.memory.csproj 
dotnet sln add interface/myapp.interface.api/myapp.interface.api.csproj 
dotnet sln add test/unit/unit.csproj 
```

### Project references

``` bash
dotnet add business/myapp.business/myapp.business.csproj reference domain/myapp.domain/myapp.domain.csproj

dotnet add infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj reference domain/myapp.domain/myapp.domain.csproj
dotnet add infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj reference business/myapp.business/myapp.business.csproj
dotnet add infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj reference infra/repository/myapp.infra.repository.memory/myapp.infra.repository.memory.csproj

dotnet add infra/repository/myapp.infra.repository.memory/myapp.infra.repository.memory.csproj reference domain/myapp.domain/myapp.domain.csproj

dotnet add interface/myapp.interface.api/myapp.interface.api.csproj reference business/myapp.business/myapp.business.csproj
dotnet add interface/myapp.interface.api/myapp.interface.api.csproj reference infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj
dotnet add interface/myapp.interface.api/myapp.interface.api.csproj reference infra/myapp.infra.mapping/myapp.infra.mapping.csproj
```


### Dependency
``` bash

dotnet add infra/myapp.infra.bootstrap/myapp.infra.bootstrap.csproj package Microsoft.Extensions.DependencyInjection
dotnet add infra/myapp.infra.mapping/myapp.infra.mapping.csproj package AutoMapper --version 13.0.1


```