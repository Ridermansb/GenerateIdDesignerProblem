Este projeto tem como objetivo discutir as melhores práticas para se trabalhar com PKs do tipo int. Aproveitamos também para extender  a discussão para as propriedades auditáveis (properties `CreateAt` e `UpdateAt`).

## O problema

Chaves primárias do tipo int gera um enorme problema de arquitetura:

1. De quem é a responsabilidade de gerar?
2. É uma boa prática a property `Id` como protected. Qual a melhor forma de setar o valor fora da camada de domínio?
3. Se a responsabilidade de gerenciar as PKs for do repositório, como garantir que dois usuários não irão gerar a mesma PK?

Muitas destas questões também se aplica aos objetos auditáveis. Por exemplo a propriedade `UpdateAt`

1. De quem é a responsabilidade de gerar?
2. É uma boa prática a property `Id` como protected. Qual a melhor forma de setar o valor fora da camada de domínio?

## O projeto

A solução é bem simples composta por 5 projetos. São eles:

 * Domain  
   *Contém as interfaces e classes de domínio*
 * Orm.NHibernate  
   *Implementação do repositório NHibernate*
 * Repository  
   *Abastração do repositório* 
 * Test  
   *Testes de unidade* 
 * Orm.NHibernate.Test  
  *Testes e integração* 

Em toda a solução você vai encontrar alguns comentários que podem ser discutidos. Todos podem ser visto na janela `TaskList`:

![Onde achar as dúvidas no projeto](http://i.imgur.com/1Wsz4mo.png)

### Requisitos

Para os testes de integração, utilizamos o LocalDb.   
Você pode baixar a base de dados neste link, ou se preferir pode recriá-la em seu SGDB. Se for o caso, lembre-se de configurar seu `App.config` no proejeto `GenerateIdDesignerProblem.Orm.NHibernate.Test`.

## Como discutir

Esta dúvida foi levantada em vários locais como no [StackOverflow](http://stackoverflow.com/questions/16879461/configure-automapper-to-return-mock-in-test-layer), no forum do [Asp.net](http://forums.asp.net/t/1911120.aspx/1?Id+property+as+protected+and+its+problems), em um grupo de discussão chamado [.Net Architects](https://groups.google.com/d/msg/dotnetarchitects/V1ct6u0zkSI/1ZuX0K2RvLAJ)(*pt-br*), foi feito [um vídeo mostrando o problema](http://www.screenr.com/yfHH)(*pt-br*) e até um [post em meu blog](http://blog.ridermansb.me/post/52001156430/propriedades-private-protected-setter-e-seus-problemas)(*pt-br*) sobre o assunto.  

De qualquer forma, como estamos no git, sinta-se livre para utilizar as Issues e enviar Pull requests.