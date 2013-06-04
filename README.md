This project aims to discuss best practices for PKs of type int. We also extend this discussion to the auditable properties (properties `CreateAt` e `UpdateAt`).

## The problem

Primary keys of type int generates a huge architectural issue:

1. Whose responsibility is it to generate?
2. It is good practice property `Id` as protected. What better way to set the value outside the domain layer?
3. If the responsibility of managing the PKs is for repository, how to ensure that two users will not generate the same PK?

Many of these issues also apply to objects auditable. For example the property `UpdateAt`

1. Whose responsibility is it to generate?
2. It is good practice property `UpdateAt` as protected. What better way to set the value outside the domain layer?

## The project

The solution is very simple consisting of 5 projects. They are:

 * Domain  
   *Contains interfaces and classes domain*
 * Orm.NHibernate  
   *Implements NHibernate repository*
 * Repository  
   *Abstraction repository* 
 * Test  
   *Unit test* 
 * Orm.NHibernate.Test  
  *Integration test for NHibernate* 

In the solution you will find some reviews that can be discussed. All can be seen in the `TaskList` window:

![Where to find questions in the project](http://i.imgur.com/1Wsz4mo.png)

### Requirements

For integration tests, we use the [LocalDB](http://www.microsoft.com/en-us/sqlserver/editions/2012-editions/express.aspx). You can use `GenerateIdDesignerProblem.Orm.NHibernate.Test.mdf` as the database, or if you prefer you can recreate it on your SGDB. Remember to set your `App.config` in yours `GenerateIdDesignerProblem.Orm.NHibernate.Test` project.

## How to discute 

This question was raised in various places such as in [StackOverflow](http://stackoverflow.com/questions/16879461/configure-automapper-to-return-mock-in-test-layer), in [Asp.net](http://forums.asp.net/t/1911120.aspx/1?Id+property+as+protected+and+its+problems) forum, in a discussion group  [.Net Architects](https://groups.google.com/d/msg/dotnetarchitects/V1ct6u0zkSI/1ZuX0K2RvLAJ)(*pt-br*), was  [recorded a video showing the problem](http://www.screenr.com/yfHH)(*pt-br*) and in [post on my blog](http://blog.ridermansb.me/post/52001156430/propriedades-private-protected-setter-e-seus-problemas)(*pt-br*) about it.  

Anyway, we are in git, feel free to use the Issues or/and send pull requests.