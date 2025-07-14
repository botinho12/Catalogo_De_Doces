# 🍬 Catálogo de Doces

Este é um catálogo de doces simples, feito para você navegar e conhecer diversas delícias. Nele, você poderá ver fotos dos doces, seus nomes e algumas informações importantes.

## ✨ Funcionalidades

- Visualização de uma lista de doces com imagens e preços
- Detalhamento de cada doce
- Cadastro e login de usuários
- Redefinição de senha
- Adição de produtos a uma lista pessoal
- Envio de orçamento via WhatsApp
---

## 🚀 Como executar o projeto no seu computador

> Este passo a passo é para quem nunca executou um projeto ASP.NET antes.

### ✅ Pré-requisitos

Antes de começar, você vai precisar instalar:

- [.NET 8.0](https://dotnet.microsoft.com/download)
- [Visual Studio 2022 (ou superior)](https://visualstudio.microsoft.com/pt-br/) com a carga de trabalho **"Desenvolvimento ASP.NET e Web"**
- Git (opcional, apenas se for clonar o repositório)

---

### 📥 1. Baixe o projeto

Você pode escolher uma das opções abaixo:

#### 🔹 Opção 1: Baixar ZIP

1. Clique no botão verde **"Code"** no topo da página
2. Selecione **"Download ZIP"**
3. Extraia os arquivos em uma pasta do seu computador

#### 🔹 Opção 2: Clonar com Git (para usuários mais experientes)

git clone https://github.com/botinho12/Catalogo_De_Doces.git
------------------------------------------------------------------------------------
Depois de baixar o projeto, siga estes passos para vê-lo funcionando:

### Abrir o Projeto no Visual Studio
Vá até a pasta onde você baixou/clonou o projeto.

Dentro dela, procure por um arquivo com a extensão .sln (por exemplo, CatalogoDoces.sln). Este é o arquivo da "solução" do projeto.

Dê um duplo clique neste arquivo .sln. O Visual Studio 2022 será aberto e carregará o projeto. Pode levar alguns segundos para carregar tudo.
------------------------------------------------------------------------------------
### Configurar o Banco de Dados
Para que o catálogo funcione, ele precisa de um lugar para guardar as informações dos doces, usuários, etc. Isso é feito em um banco de dados.

### Ajustar a Conexão com o Banco de Dados
* No Visual Studio, no lado direito, você verá a janela "Gerenciador de Soluções".

* Procure e abra o arquivo chamado appsettings.json (ou Web.config se for um projeto mais antigo).

* Dentro deste arquivo, você encontrará uma parte que se parece com isto:
      "ConnectionStrings": {
            "DefaultConnection": "Server=BOTECO\\SQLEXPRESS;Database=DocesDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"

* Ajuste a parte do Server= para o nome do seu servidor de banco de dados.
* Por exemplo, se você estiver usando o SQL Server Express com a instância padrão, pode ser Server=.\SQLEXPRESS ou Server=(localdb)\\mssqllocaldb.

* Não mude o Database=DocesDb se você quiser manter o nome do banco de dados como DocesDb.

### Criar e Atualizar o Banco de Dados ###
Depois de ajustar a conexão, precisamos criar o banco de dados e as tabelas necessárias.

No Visual Studio, vá no menu superior em "Ferramentas" > "Gerenciador de Pacotes NuGet" > "Console do Gerenciador de Pacotes".

Uma nova janela preta (o console) vai aparecer na parte inferior do Visual Studio.

Nela, digite o seguinte comando e pressione Enter: dotnet ef database update

Este comando vai criar o banco de dados e todas as tabelas necessárias para o projeto funcionar, usando as configurações que você ajustou no appsettings.json.

Aguarde até que o comando termine de executar e mostre uma mensagem de sucesso.
------------------------------------------------------------------------------------
### Rodar o Catálogo ###
Com o projeto aberto no Visual Studio, procure na parte superior, na barra de ferramentas, por um botão que geralmente tem o texto "IIS Express" e o nome do seu projeto (ex: "IIS Express CatalogoDoces"), acompanhado de um ícone de "Play" (▶).

* Clique neste botão de "Play".

* O Visual Studio irá compilar (preparar) o projeto e, em seguida, uma janela do seu navegador de internet padrão (como Chrome, Edge ou Firefox) será aberta automaticamente.

* Pronto! Você verá o Catálogo de Doces funcionando no seu navegador.

## Segui algumas imagens do site ##

## Tela Inicial ##
<p align="center">
  <img src="https://github.com/user-attachments/assets/beaabb13-77ba-4dcf-a3ff-1e43a6bb2fd3" width="600">
</p>

## Tela Do Catalogo de Produtos ##
<p align="center">
  <img src="https://github.com/user-attachments/assets/d01c50c1-d1c8-4cd9-8bab-bf36cbd967d5" width="600">
</p>

## Lista de Produtos Adicionados ##
<p align="center">
  <img src="https://github.com/user-attachments/assets/1bd05626-164c-400d-bd2d-a362739bd096" width="600">
</p>

## Tela do Admin mostrando produtos existentes ##
<p align="center">
  <img src="https://github.com/user-attachments/assets/75036294-7242-40db-989e-b77bc4d37a69" width="600">
</p>








  









