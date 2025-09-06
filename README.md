===============================================================================

                    EXERCÍCIO PRÁTICO: TIPOS DE ACTIONS NO ASP.NET CORE MVC

===============================================================================



OBJETIVO:

Criar uma aplicação MVC que demonstre o uso dos três principais tipos de 

Actions: ViewResult, JsonResult e FileResult.



CENÁRIO:

Você deve criar um sistema simples de gerenciamento de produtos para uma loja.



===============================================================================

REQUISITOS DO EXERCÍCIO:

===============================================================================



1. CRIAR O MODEL:

   - Crie uma classe "Produto" com as seguintes propriedades:

     * Id (int)

     * Nome (string)

     * Preco (decimal)

     * Categoria (string)

     * EmEstoque (bool)

     * DataCadastro (DateTime)



2. CRIAR O CONTROLLER "ProdutoController" COM AS SEGUINTES ACTIONS:



   A) ViewResult Actions:

      - Index(): Exibir lista de todos os produtos em uma tabela

      - Detalhes(int id): Mostrar detalhes de um produto específico

      - Categoria(string categoria): Filtrar produtos por categoria



   B) JsonResult Actions:

      - ObterProdutosJson(): Retornar todos os produtos em formato JSON

      - BuscarProduto(int id): Retornar um produto específico em JSON

      - ProdutosPorCategoria(string categoria): Retornar produtos filtrados em JSON



   C) FileResult Actions:

      - ExportarCsv(): Gerar arquivo CSV com lista de produtos

      - RelatorioTxt(): Gerar relatório em texto com estatísticas

      - ExportarJson(): Baixar arquivo JSON com todos os produtos



3. CRIAR AS VIEWS:



   A) Views/Produto/Index.cshtml:

      - Tabela listando produtos (Nome, Preço, Categoria, Em Estoque)

      - Link "Ver Detalhes" para cada produto

      - Botão para obter dados em JSON (usar JavaScript/AJAX)

      - Links para download dos arquivos (CSV, TXT, JSON)

      - Filtro por categoria (dropdown com botão "Filtrar")



   B) Views/Produto/Detalhes.cshtml:

      - Mostrar todas as informações do produto

      - Link "Voltar à Lista"



   C) Views/Produto/Categoria.cshtml:

      - Mostrar produtos filtrados por categoria

      - Indicar qual categoria está sendo exibida

      - Link "Ver Todos os Produtos"



4. DADOS PARA TESTE:

   Crie uma lista estática com pelo menos 6 produtos de diferentes categorias:

   - Eletrônicos (Smartphone, Notebook)

   - Roupas (Camiseta, Calça)

   - Livros (Romance, Técnico)



===============================================================================

ESPECIFICAÇÕES TÉCNICAS:

===============================================================================



VIEWRESULT:

- Deve retornar views com dados do model

- Usar @model nas views para tipar os dados

- Implementar navegação entre as páginas



JSONRESULT:

- Retornar dados em formato JSON

- Incluir propriedades de sucesso/erro nas respostas

- Formatar datas adequadamente no JSON

- Tratar casos de "não encontrado"



FILERESULT:

- CSV: Incluir cabeçalhos e dados separados por vírgula

- TXT: Criar relatório legível com estatísticas (total, por categoria, etc.)

- JSON: Exportar dados completos em formato JSON válido

- Usar nomes de arquivo apropriados

- Definir Content-Type correto para cada tipo



===============================================================================

ENTREGÁVEIS:

===============================================================================



1. Models/Produto.cs

2. Controllers/ProdutoController.cs

3. Views/Produto/Index.cshtml

4. Views/Produto/Detalhes.cshtml

5. Views/Produto/Categoria.cshtml

6. Atualizar navegação no _Layout.cshtml

===============================================================================

DICAS:

===============================================================================



- Use List<Produto> estática para simular banco de dados

- Para filtros, use LINQ: lista.Where(p => p.Categoria == categoria).ToList()

- Para CSV, use StringBuilder para construir o conteúdo

- Para JSON personalizado, crie objetos anônimos: new { sucesso = true, dados = lista }

- Use DateTime.Now para DataCadastro dos produtos de teste

- Teste todos os downloads e verificações de JSON no navegador

===============================================================================

                    EXERCÍCIO PRÁTICO: TIPOS DE ACTIONS NO ASP.NET CORE MVC

===============================================================================



OBJETIVO:

Criar uma aplicação MVC que demonstre o uso dos três principais tipos de 

Actions: ViewResult, JsonResult e FileResult.



CENÁRIO:

Você deve criar um sistema simples de gerenciamento de produtos para uma loja.



===============================================================================

REQUISITOS DO EXERCÍCIO:

===============================================================================



1. CRIAR O MODEL:

   - Crie uma classe "Produto" com as seguintes propriedades:

     * Id (int)

     * Nome (string)

     * Preco (decimal)

     * Categoria (string)

     * EmEstoque (bool)

     * DataCadastro (DateTime)



2. CRIAR O CONTROLLER "ProdutoController" COM AS SEGUINTES ACTIONS:



   A) ViewResult Actions:

      - Index(): Exibir lista de todos os produtos em uma tabela

      - Detalhes(int id): Mostrar detalhes de um produto específico

      - Categoria(string categoria): Filtrar produtos por categoria



   B) JsonResult Actions:

      - ObterProdutosJson(): Retornar todos os produtos em formato JSON

      - BuscarProduto(int id): Retornar um produto específico em JSON

      - ProdutosPorCategoria(string categoria): Retornar produtos filtrados em JSON



   C) FileResult Actions:

      - ExportarCsv(): Gerar arquivo CSV com lista de produtos

      - RelatorioTxt(): Gerar relatório em texto com estatísticas

      - ExportarJson(): Baixar arquivo JSON com todos os produtos



3. CRIAR AS VIEWS:



   A) Views/Produto/Index.cshtml:

      - Tabela listando produtos (Nome, Preço, Categoria, Em Estoque)

      - Link "Ver Detalhes" para cada produto

      - Botão para obter dados em JSON (usar JavaScript/AJAX)

      - Links para download dos arquivos (CSV, TXT, JSON)

      - Filtro por categoria (dropdown com botão "Filtrar")



   B) Views/Produto/Detalhes.cshtml:

      - Mostrar todas as informações do produto

      - Link "Voltar à Lista"



   C) Views/Produto/Categoria.cshtml:

      - Mostrar produtos filtrados por categoria

      - Indicar qual categoria está sendo exibida

      - Link "Ver Todos os Produtos"



4. DADOS PARA TESTE:

   Crie uma lista estática com pelo menos 6 produtos de diferentes categorias:

   - Eletrônicos (Smartphone, Notebook)

   - Roupas (Camiseta, Calça)

   - Livros (Romance, Técnico)



===============================================================================

ESPECIFICAÇÕES TÉCNICAS:

===============================================================================



VIEWRESULT:

- Deve retornar views com dados do model

- Usar @model nas views para tipar os dados

- Implementar navegação entre as páginas



JSONRESULT:

- Retornar dados em formato JSON

- Incluir propriedades de sucesso/erro nas respostas

- Formatar datas adequadamente no JSON

- Tratar casos de "não encontrado"



FILERESULT:

- CSV: Incluir cabeçalhos e dados separados por vírgula

- TXT: Criar relatório legível com estatísticas (total, por categoria, etc.)

- JSON: Exportar dados completos em formato JSON válido

- Usar nomes de arquivo apropriados

- Definir Content-Type correto para cada tipo



===============================================================================

ENTREGÁVEIS:

===============================================================================



1. Models/Produto.cs

2. Controllers/ProdutoController.cs

3. Views/Produto/Index.cshtml

4. Views/Produto/Detalhes.cshtml

5. Views/Produto/Categoria.cshtml

6. Atualizar navegação no _Layout.cshtml

===============================================================================

DICAS:

===============================================================================



- Use List<Produto> estática para simular banco de dados

- Para filtros, use LINQ: lista.Where(p => p.Categoria == categoria).ToList()

- Para CSV, use StringBuilder para construir o conteúdo

- Para JSON personalizado, crie objetos anônimos: new { sucesso = true, dados = lista }

- Use DateTime.Now para DataCadastro dos produtos de teste

- Teste todos os downloads e verificações de JSON no navegador
