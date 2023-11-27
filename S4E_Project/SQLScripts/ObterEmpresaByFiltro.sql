
CREATE PROCEDURE ObterEmpresaByFiltro  
    @Id INT = NULL,  
    @Nome NVARCHAR(MAX) = '',  
    @Cnpj VARCHAR(11) = ''  
AS   
BEGIN  
    DECLARE @sql NVARCHAR(MAX)  
    SET @sql = 'SELECT Id, Nome, Cnpj FROM Empresa WHERE 1=1'  
  
    IF @Id IS NOT NULL AND @Id > 0  
    BEGIN  
        SET @sql = @sql + ' AND Id = ' + CAST(@Id AS NVARCHAR(MAX)) + ' '  
    END  
  
    IF @Nome IS NOT NULL AND @Nome != ''  
    BEGIN   
        SET @sql = @sql + ' AND Nome LIKE ''%' + @Nome + '%'''  
    END  
  
    IF @Cnpj IS NOT NULL AND @Cnpj != ''  
    BEGIN  
        SET @sql = @sql + ' AND Cpf = ''' + @Cnpj + ''''  
    END  
  
    SET @sql = @sql + ' ORDER BY Nome'  
    EXEC(@sql)  
END