Create Procedure DeletarAssociadoById (@id Int)
as 
begin
delete Associado where Id = @id

delete Associado_Empresa where Associado_Id = @id
end

