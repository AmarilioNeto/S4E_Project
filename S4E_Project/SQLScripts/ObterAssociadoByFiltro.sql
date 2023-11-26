CREATE PROCEDURE ObterAssociadoByFiltro
    @Id INT = NULL,
    @Nome NVARCHAR(MAX) = '',
    @Cpf VARCHAR(11) = '',
    @DataNascimento DATE = ''
AS 
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @sql = 'SELECT Id, Nome, Cpf, DataNascimento FROM Associado WHERE 1=1'

    IF @Id IS NOT NULL AND @Id > 0
    BEGIN
        SET @sql = @sql + ' AND Id = ' + CAST(@Id AS NVARCHAR(MAX)) + ' '
    END

    IF @Nome IS NOT NULL AND @Nome != ''
    BEGIN 
        SET @sql = @sql + ' AND Nome LIKE ''%' + @Nome + '%'''
    END

    IF @Cpf IS NOT NULL AND @Cpf != ''
    BEGIN
        SET @sql = @sql + ' AND Cpf = ''' + @Cpf + ''''
    END

    IF @DataNascimento IS NOT NULL AND @DataNascimento != ''
    BEGIN
        SET @sql = @sql + ' AND DataNascimento = ''' + CONVERT(NVARCHAR(MAX), @DataNascimento, 23) + ''' '
    END

    SET @sql = @sql + ' ORDER BY Nome'
    EXEC(@sql)
END