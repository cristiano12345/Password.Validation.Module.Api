
## **Desafio Backend CRISTIANO ANDRADE**

## **Critério de validação**

Uma senha é considerada válida quando a mesma atender as seguintes regras:

- Nove ou mais caracteres
- Não possuir caracteres repetidos dentro do conjunto
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Os caracteres especiais aceitos são: ! @ # $ % ^ & * ( ) - +

Exemplo:  

```c#
IsValid("") // false  
IsValid("aa") // false  
IsValid("ab") // false  
IsValid("AAAbbbCc") // false  
IsValid("AbTp9!foo") // false  
IsValid("AbTp9!foA") // false
IsValid("AbTp9 fok") // false
IsValid("AbTp9!fok") // true
```

> **_Nota:_**  Espaços em branco não são considerados como caracteres válidos.

## **Arquitetura**
*Clean Architecture foi a filosofia de design de software escolhida como padrão foi utilizada  
para facilitar o desenvolvimento, manutenção e desacoplamento.

*CQRS Pattern foi implementado para manter responsabilidades de leitura(em uma feature futura...) e escrita segregadas
isso pode nos garantir escalabilidade e melhor padrão organizacional 

*Specification Pattern é um padrão de design de software, 
onde regras de negócio podem ser recombinadas através de lógica booleana, 
podemos respeitar varios principios do SOLID com a aplicação deste patter ex: "Single Responsibility Principle" + "open–closed principle"
segregando responsabilidades e estando pronto para extender sem modificar 

*RESTful foi o modelo escolhido como interface de programação da aplicação(API)

### **Organização da Solução**

O projeto está organizado da seguinte forma:

```
 +- Password.Validation.Module.Api
 |
 +- Password.Validation.Module.Application
 |
 +- Password.Validation.Module.Contract
 |
 +- Password.Validation.Module.CrossCutting
 |
 +- Password.Validation.Module.Service
 |
 +- Password.Validation.Module.Test 
```

Onde:

* `Password.Validation.Module.Api`: Interface de programação da aplicação *(API)*
* `Password.Validation.Module.Application`: *Handlers* e casos de uso da aplicação
* `Password.Validation.Module.Contract`: Entidades e contratos da aplicação.
* `Password.Validation.Module.Service`: Regras de negocio da aplicação.
* `Password.Validation.Module.CrossCutting`: Container de Injeção de Dependência Ioc.
* `Password.Validation.Module.Test`: Aqui garantimos a integridade das alterações e aumentamos a qualidade da aplicação *Testes*.

## **Endpoint**

```c#
POST /api/password/validate
```

## **Requisição**

```c#
{
  "password": "string"
}
```

## **Resposta**
```c#
{
  "password": true|false
}
```

## **Execução usando Visual Studio**

* Clone este repositório
* Abra o projeto através do arquivo [`Password.Validation.Module.sln`]
* Defina o projeto `Password.Validation.Module.Api` como sendo o *start-up* da solução.
* Selecione o perfil de execução como `Kestrel`.
* Cliquem no menu `Debug` e em seguida na opção `Start Debugging` ou simplesmente pressione `F5`.
* Abra o navegador de sua preferência e acesse o endereço [http://localhost:5000] ou http://localhost:5000/swagger/index.html])
* Uma página do swagger com a documentação da api será apresentada e com opção de realização de chamadas de testes (`try out`)

## **SUCCESS......................**

