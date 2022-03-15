
﻿
![enter image description here](http://www.qualitysys.com.br/novo/assets/img/colors/blue/logoQuality2.png)

# **Seja bem vindo ao Repositório de Provas da Quality Systems**

# Escopo

 1. Projeto definido em WebAPI (.Net Core 5).
 2. Conexão com banco de dados SQL Server.


# Objetivo do teste (Vaga Jr.):

 - Criar uma action do tipo POST, que servirá  como uma API de busca de resultados.
 - Pegar dados da tabela contaPagamento, referenciada pela classe Data.ContaPagamento().
	 	 - Aplicar os filtros:
		 	 - descricao
		 	 - idEmpresa
 - Limitar somente 10 registros.
 - Retornar um array com todos os registros.
---------------------------
 - Criar uma action do tipo GET, que servirá como uma API de detalhamento de registro.
 - Pegar dados da tabela contaPagamento, referenciada pela classe Data.ContaPagamento().
		 	 - idContaPagamento
 - Retornar um objeto com os dados do registro em questão.


# Objetivo do teste (Vaga Pleno):

 - Criar uma action do tipo POST, que servirá  como uma API de busca de resultados.
 - Pegar dados da tabela contaPagamento, referenciada pela classe Data.ContaPagamento().
	 	 - Aplicar os filtros:
		 	 - descricao
		 	 - idEmpresa
 - Limitar somente 10 registros.
 - Retornar um array com todos os registros.

 - Neste mesmo controller, a função UtilsApi.Grid().FillFormComponentFields() para a classe Data.ContaPagamento() não está retornando o parâmetro "descrição" para todas as colunas, ou seja, a coluna é adicionada no array de colunas, porém sua descrição vem em branco. O candidato deverá debugar o programa para poder encontrar o erro e propor uma solução para este problema. (Este problema em ambiente de produção já está solucionado).
---------------------------
 - Criar uma action do tipo GET, que servirá como uma API de detalhamento de registro.
 - Pegar dados da tabela contaPagamento, referenciada pela classe Data.ContaPagamento().
		 	 - idContaPagamento
 - Retornar um objeto com os dados do registro em questão.

 

# DOCUMENTAÇÃO

Adicionar as seguintes dependências no projeto QualityDLL via NuGET:
- System.Data.sqlclient
- Newtonsoft.Json

# Classes Auxiliares

 1. Utils.cs
 2. Classe responsável por diversas funções auxiliares do sistema.
 3. Auxilia na conexão com o banco de dados, traduzindo o resultado das consultas para nossas classes internas.

# Namespaces importantes

Toda tabela em nosso banco de dados é representada por um conjunto de classes, separadas em 3 namespaces diferentes:
	 - CRUD
	 - Data
	 - Tables

**Data:**
Namespace responsável por criar o corpo da tabela em forma de classe. Sempre que quiser chamar uma tabela do banco de dados, deverá instanciar sua respectiva classe no namespace Data.
**Por exemplo:**
Tabela: ***usuario***
Deverá ser instanciada a classe:  ***Data.Usuario()***

**CRUD:**
Namespace responsável por armazenar lógica de INSERT, UPDATE, DELETE no banco de dados. 
Possui funções auxiliares para tradução dos resultados do SQL para as classes do namespace Data.

**Tables:**
Namespace responsável pela arquitetura das tabelas em forma de classe. Toda tabela do banco de dados deve ter sua respectiva classe no namespace Tables.



## Exemplos de uso:

**Consulta na tabela ***usuario*** para um usuário específico:**

   
```c#
Data.Usuario usuario = new Data.Usuario
{
    idUsuario = 1
};
usuario = (Data.Usuario)Utils.Utils.sr(0).consultar(usuario);
```
	
Toda classe do namespace ***Data*** herda a classe ***Base***.
A função ***consultar()*** recebe como parâmetro um objeto do tipo ***Data.Base()*** e retorna um objeto derivado do Data.Base(), portanto sendo necessário fazer o cast.

Caso a consulta retornar algum erro, ou seja, a variável ***usuario*** retornar null ou, sua propriedade atribuída como chave primária (***idUsuario***) for igual a zero.
```c#
/* Código para verificação de resultado */
if(usuario == null || (usuario != null && usuario.idUsuario == 0)) {
    throw new Exception("Usuário não encontrado!");
}
```

********************************************
**Consulta na tabela usuario para uma lista de dados:**
```c#
/* Deve ser instaciada a classe Data da respectiva tabela */
Data.Usuario usuario = new Data.Usuario();

/* Chamar a classe função listaDados */
List<Data.Base> listaUsuarios = Utils.Utils.listaDados(0, usuario, 0, null);
```
O exemplo acima irá listar todos os usuários sem nenhum filtro.
Para aplicar filtros, basta instanciar as propriedades da classe, por exemplo:

```c#
/* Deve ser instaciada a classe Data da respectiva tabela */
Data.Usuario usuario = new Data.Usuario
{
	nomeUsuario = "teste"
};

/* Chamar a classe função listaDados */
List<Data.Base> listaUsuarios = Utils.Utils.listaDados(0, usuario, 0, null);
```
    

Dessa forma, o sistema automaticamente traduzira para um select no banco de dados, no qual a coluna ***nomeUsuario*** seja igual a ***'teste'***

***************************************************
**Assinatura da função Utils.Utils.listaDados()**
A função listaDados possui várias assinaturas, porém a mais importante é:

Utils.Utils.listaDados(int idEmpresa, Data.Base classeBase, int numRows, List<Utils.NameValue> parameters)

Seu retorno é um array do mesmo tipo do parâmetro **classeBase**.

**Descrição dos parâmetros:**
 - idEmpresa (O sistema é multi-empresa, portanto é necessário informar o ID da empresa que está fazendo a consulta. Essa informação pode ser obtida pelo front-end ou pelo atributo ***idEmpresa*** da classe ***ControllerQuality***)
 - classeBase: A classe na qual deseja efetuar a consulta, no nosso exemplo, Data.Usuario().
 - numRows: Parâmetro para limitar a quantidade de resultados da consulta no banco, útil para paginação
 - parameters: É uma lista responsável por passar informações adicionais ao CRUD de comunicação com o banco de dados. É possível passar os seguintes atributos nesta lista:
	 - **Order** -> Responsável pela ordenação dos registros
	 - **Mode** -> Responsável por fazer uma consulta mais simplificada, basta passar o valor **Roll**.
	 - **Filter** -> Responsável por passar filtros em que não seja possível fazer diretamente na classe, como intervalos, validação de valores booleanos. O valor deste parâmetro é em SQL, ou seja, será transmitido automaticamente para a cláusula WHERE da consulta
	 - **Offset** -> Responsável por determinar o início dos registros, útil para paginação de dados, basta passar o nome **startRowindex** e o valor do tipo *int* no atributo **Value**.
	```c#
	 _params.Add(new Utils.NameValue { name = "Offset", value = 0 });
	 ```

Normalmente, os controllers herdam da classe **ControllerBase**, porém em nosso contexto, temos uma classe auxiliar chamada **ControllerQuality**, que possui diversos métodos que auxiliam na manipulação dos dados da API.

Exemplo da utilização de um Controller para listagem de vários dados:
```c#
	[
        Route("api/[controller]"),
        ApiController
    ]
    public class ContasAReceberController : ControllerQuality
    {
    [
            Route(""),
            HttpGet
        ]
        public async Task<ActionResult<dynamic>> Detalhe()
        {
            try
            {
                /*
                 * O JSON do REQUEST deve ter o mesmo corpo da classe em questão, no caso Data.ContasAReceber */
                var body = await this.GetBody<Data.ContasAReceber>();

                if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else { }

                Data.ContasAReceber key = new Data.ContasAReceber();

                /* ID empresa que vem do front-end, */
                key.idEmpresa = this.idEmpresa;

                /* Instanciamos a classe NameValue, para passar parâmetros adicionais a consulta */
                List<Utils.NameValue> _params = new List<Utils.NameValue>();

                /* 
                 * Adicionamos na lista _params a opção de ORDER BY, ordenando pelo campo dataVencimento da tabela contasAReceber 
                 * Essa função deve-se passar SQL Nativo, ou seja, seria traduzido para:  ORDER BY contasAReceber.dataVencimento
                 */
                _params.Add(new Utils.NameValue { name = "Order", value = "contasAReceber.dataVencimento" });

                /*
                 * Chama a função listaDados, passando:
                 * idEmpresa
                 * classeBase
                 * numero de linhas
                 * parâmetros adicionais da consulta
                 */
                List<Data.Base> results = Utils.Utils.listaDados(this.idEmpresa, key, this.maxRowsPerPage, _params);

		/* Criamos um novo objeto para retorno ao front-end */
		var obj = new
                {
                    totalRows = Utils.Utils.getCount(idEmpresa, key, _parameters),
                    maxRowsPerPage,
                    startRowIndex,
                    results,
		    
		    /* A função FillFormComponentFields é responsável por gerar um GRID automático, de acordo com a estrutura da classe em questão. 
		    * Esse grid é enviado ao front end e transformado em HTML.
		    */
                    grid = GenerateGrid ? new UtilsApi.Grid().FillFormComponentFields(key.GetType(), false) : new GridModel { }
                };

		/*
                 * Utilizamos a função Retorno, para transformar o objeto em JSON, respeitando suas tipagens.
                 */
                return UtilsGestao.UtilsApi.Retorno(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
    }
```

Exemplo da utilização de um Controller para listagem de um único dado:
```c#
	[
        Route("api/[controller]"),
        ApiController
    ]
    public class ContasAReceberController : ControllerQuality
    {
        [
            Route(""),
            HttpGet
        ]
        public async Task<ActionResult<dynamic>> Detalhe()
        {
            try
            {
                /*
                 * O JSON do REQUEST deve ter o mesmo corpo da classe em questão, no caso Data.ContasAReceber */
                var body = await this.GetBody<Data.ContasAReceber>();

                if (body == null)
                    throw new Exception("Parâmetros incorretos!");
                else { }

                Data.ContasAReceber cr = new Data.ContasAReceber();

                /* ID do Contas A Receber que desejo detalhar, obtido do front-end, */
                cr.idContasAReceber = body.idContasAReceber;

                /* Instanciamos a classe NameValue, para passar parâmetros adicionais a consulta */
                List<Utils.NameValue> _params = new List<Utils.NameValue>();

                /*
                 * Chama a função sr.consultar(), passando:
                 * classeBase
                 * 
                 * Irá retornar somente um registro, ou seja, o registro passado na variável body.idContasAReceber
                 */
                cr = (Data.ContasAReceber)sr.consultar(cr);

                /*
                 * Utilizamos a função Retorno, para transformar o objeto em JSON, respeitando suas tipagens.
                 */
                return UtilsGestao.UtilsApi.Retorno(cr);
            }
            catch (Exception ex)
            {
                return BadRequest(UtilsGestao.UtilsApi.CatchError(ex));
            }
        }
    }
```



