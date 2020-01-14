# EstoqueAPI
Exemplo de Sistema para estoque de produtos

  O sistema foi pensado um serviço que tem como base teórica os preceitos do DDD e de uma arquitetura hexagonal. O solução se divide em projetos que tentam ao máximo dar as suas unidades capacidade de se comportar com o princípio da responsabilidade única e o de aberto e fechado, inversão de dependência/inversão de controle e abstração.
  
  O projeto utiliza como camadas Class Librarys para o .NET Core que poderiam ser substituídas por .NET Standard caso necessário para um microserviços mais agnóstico tecnologicamente. Utiliza como ORM o EntityFrameworkCore 3.1.
  
  -Padrão de Repositório é usado para fazer essa comunicação entre a camada de mapeamento e a camada de domínio para fazer as transações sem presença de regras de negócio.
  
  -Padrão de Serviços para agir como a ferramente que irá chamar a camada transacional/infraestrutura e manterá as regras de negócio.
  
  -Padrão de Specification para que futuramente com a ammpliação para um sistema de estoque completo, seja possível reaproveitar o mesmo para segmentar de maneira mais atomizada sem reescrita as transações de banco para cada domínio.
  
  -UnitOfWork como padrão de unidade de trabalho de design pattern, AutoMapper como OOM para facilitar a segregação entre objetos de domínio e objetos de mapeamento.
  
  -Uma camada de presentation para realizar a comunicação a Front-end com total desconhecimento da nossa camada de dados para manter um desacoplamento desejável. 
  
  Sistema pode ainda contar como evolutivas em questão de versionamento, autenticação e tratamento específico de exceção que foram deixados de lado pela simplicidade da história do usuário, swagger para teste da API e integrações para CD E CI com unidades de teste como  SonarQube, Selenium e etc. 
