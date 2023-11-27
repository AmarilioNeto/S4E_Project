
 CREATE procedure UpdateAssociadoEmpresa (@Cnpj nvarchar(14), @IdAssociado int, @cpf nvarchar(11))      
as       
begin      
declare @Id_Associado int      
declare @Id_Empresa int      
declare @Id_relacionamento int    
select @Id_relacionamento = Id from Associado_Empresa where  Associado_Id = @IdAssociado and Empresa_CNPJ =@Cnpj   
Update Associado_Empresa     
Set     
Associado_CPF =  @Cpf,      
Empresa_CNPJ= @Cnpj     
where     
Id = @Id_relacionamento    
end
