
CREATE Procedure DeletarEmpresaById (@id Int)  
as   
begin  
delete Empresa where Id = @id  
delete Associado_Empresa where Empresa_Id = @id  
end