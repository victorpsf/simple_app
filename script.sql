DROP DATABASE `recorte_de_coracao`;
CREATE DATABASE `recorte_de_coracao` CHAR SET 'utf16';

USE `recorte_de_coracao`;

SET FOREIGN_KEY_CHECKS = 0;

CREATE TABLE `Acesso` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `EMAIL`         VARCHAR(300) NOT NULL,
    `NOME USUARIO`  VARCHAR(300),
    `CHAVE`   		TEXT NOT NULL,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM` DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Endereco` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CEP`           INT NOT NULL,
    `RUA`           VARCHAR(300) NOT NULL,
    `COMPLEMENTO`   VARCHAR(300),
    `OUTROS`        TEXT,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM` DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Pessoa` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `NOME`            VARCHAR(300) NOT NULL,
    `CPF`             INT NOT NULL,
    `RG`              INT,
    `DATA NASCIMENTO` DATE NOT NULL,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Contato` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `EMAIL`           VARCHAR(300),
    `TELEFONE`        INT,
    `OUTROS`          TEXT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Arquivo` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `Nome`            VARCHAR(300) NOT NULL,
    `Extensao`        VARCHAR(300) NOT NULL,
    `Tamanho`         INT UNSIGNED NOT NULL,
    `Binario`         LONGBLOB NOT NULL,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Entrada Financeira` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `VALOR`           DECIMAL(12, 2) UNSIGNED NOT NULL,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Saida Financeira` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `VALOR`           DECIMAL(12, 2) UNSIGNED NOT NULL,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Modelo` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `NOME`          VARCHAR(300) NOT NULL,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM` DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Produto` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `NOME`          VARCHAR(300) NOT NULL,
    `VALOR`         DECIMAL(10,2) NOT NULL,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM` DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Modelo Produto` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM` DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,

    `MODELO ID`     INT UNSIGNED NOT NULL,
    `PRODUTO ID`    INT UNSIGNED NOT NULL,

    FOREIGN KEY (`MODELO ID`) REFERENCES `Modelo`(`ID`),
    FOREIGN KEY (`PRODUTO ID`) REFERENCES `Produto`(`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Historico Preco` (
	`ID`            INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `VALOR`         DECIMAL(10,2) NOT NULL,
    `CRIADO EM`     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `DELETADO EM`   DATETIME,
    
	`PRODUTO ID`    INT UNSIGNED NOT NULL,
    
    FOREIGN KEY (`PRODUTO ID`) REFERENCES `Produto`(`ID`),
    
    PRIMARY KEY (`ID`)
);

CREATE TABLE `Galeria Produto` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,

    `PRODUTO ID`      INT UNSIGNED NOT NULL,
    `IMAGEM ID`       INT UNSIGNED NOT NULL,

    FOREIGN KEY (`PRODUTO ID`) REFERENCES `Produto` (`ID`),
    FOREIGN KEY (`IMAGEM ID`)  REFERENCES `Arquivo`    (`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Cliente` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,

    `PESSOA ID`       INT UNSIGNED NOT NULL,
    `ENDERECO ID`     INT UNSIGNED NOT NULL,
    `CONTATO ID`      INT UNSIGNED NOT NULL,
    
    FOREIGN KEY (`PESSOA ID`)   REFERENCES `Pessoa`   (`ID`),
    FOREIGN KEY (`ENDERECO ID`) REFERENCES `Endereco` (`ID`),
    FOREIGN KEY (`CONTATO ID`)  REFERENCES `Contato`  (`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Pedido` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    `STATUS`          INT(4) UNSIGNED NOT NULL,
    `DATA PEDIDO`     DATE NOT NULL,
    `DATA ENTREGA`    DATETIME NOT NULL,

    `CLIENTE ID`      INT UNSIGNED NOT NULL,

    FOREIGN KEY (`CLIENTE ID`) REFERENCES `Cliente` (`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Pedido Produto` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,
    `QUANTIDADE`      INT UNSIGNED NOT NULL,
    `VALOR TOTAL`     DECIMAL(10,2) NOT NULL,

    `PRODUTO ID`      INT UNSIGNED NOT NULL,
    `PEDIDO ID`      INT UNSIGNED NOT NULL,

    FOREIGN KEY (`PRODUTO ID`) REFERENCES `Produto` (`ID`),
    FOREIGN KEY (`PEDIDO ID`) REFERENCES `Pedido` (`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Pagamento Pedido` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,

    `PEDIDO ID`              INT UNSIGNED NOT NULL,
    `ENTRADA FINANCEIRA ID`  INT UNSIGNED NOT NULL,

    FOREIGN KEY (`PEDIDO ID`) REFERENCES `Pedido` (`ID`),
    FOREIGN KEY (`ENTRADA FINANCEIRA ID`) REFERENCES `Entrada Financeira` (`ID`),

    PRIMARY KEY (`ID`)
);

CREATE TABLE `Comprovante Pagamento` (
	`ID`              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `CRIADO EM`       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `ATUALIZADO EM`   DATETIME NULL ON UPDATE CURRENT_TIMESTAMP,
    `DELETADO EM`     DATETIME,

    `ENTIDADE ID`         INT UNSIGNED NOT NULL,
    `ENTIDADE NAME`       VARCHAR(300) NOT NULL,
    `ARQUIVO ID`          INT UNSIGNED NOT NULL,

    FOREIGN KEY (`ARQUIVO ID`)          REFERENCES `Arquivo` (`ID`),

    PRIMARY KEY (`ID`)
);

SET FOREIGN_KEY_CHECKS = 1;