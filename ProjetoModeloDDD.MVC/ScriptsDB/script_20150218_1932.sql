CREATE TABLE [dbo].[Configuracao] (
    [ConfiguracaoId] [int] NOT NULL IDENTITY,
    [CaminhoArquivoImportacao] [varchar](100),
    [CaminhoArquivoExportacao] [varchar](100),
    CONSTRAINT [PK_dbo.Configuracao] PRIMARY KEY ([ConfiguracaoId])
)
CREATE TABLE [dbo].[LayoutImportacao] (
    [LayoutImportacaoId] [int] NOT NULL IDENTITY,
    [NomeCampo] [varchar](100),
    [Tamanho] [varchar](100),
    [Tipo] [varchar](100),
    [Observacao] [varchar](100),
    CONSTRAINT [PK_dbo.LayoutImportacao] PRIMARY KEY ([LayoutImportacaoId])
)
CREATE TABLE [dbo].[ProdutoImportacao] (
    [ProdutoImportacaoId] [int] NOT NULL IDENTITY,
    [NumeroLoja] [int] NOT NULL,
    [Data] [datetime] NOT NULL,
    [CodigoEan] [int] NOT NULL,
    [PrecoUnitario] [decimal](18, 2) NOT NULL,
    [Quantidade] [decimal](18, 2) NOT NULL,
    [secao] [int] NOT NULL,
    [identificador] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ProdutoImportacao] PRIMARY KEY ([ProdutoImportacaoId])
)

ALTER TABLE [dbo].[Configuracao] ALTER COLUMN [CaminhoArquivoImportacao] [nvarchar](max) NOT NULL
ALTER TABLE [dbo].[Configuracao] ALTER COLUMN [CaminhoArquivoExportacao] [nvarchar](max) NOT NULL
ALTER TABLE [dbo].[LayoutImportacao] ALTER COLUMN [NomeCampo] [nvarchar](200) NOT NULL
ALTER TABLE [dbo].[LayoutImportacao] ALTER COLUMN [Tamanho] [nvarchar](max) NOT NULL
ALTER TABLE [dbo].[LayoutImportacao] ALTER COLUMN [Tipo] [nvarchar](50) NOT NULL