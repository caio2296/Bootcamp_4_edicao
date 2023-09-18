CREATE TABLE [dbo].[Produto] (
    [IdProduto] INT             IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (50)    NULL,
    [Preco]     DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([IdProduto] ASC)
);