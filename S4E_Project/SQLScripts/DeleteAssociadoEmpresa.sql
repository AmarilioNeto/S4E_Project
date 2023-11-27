
Create procedure DeleteAssociadoEmpresa (@Cnpj nvarchar(14), @Cpf nvarchar(11))    
as     
begin    
declare @Id_Associado int    
declare @Id_Empresa int    
declare @Id_relacionamento int  
select @Id_Associado = Id from Associado where  Cpf =  @cpf   
select @Id_Empresa = Id from Empresa where Cnpj = @Cnpj   
select @Id_relacionamento = Id from Associado_Empresa Where Associado_Id = @Id_Associado  and Empresa_Id = @Id_Empresa  
  
delete Associado_Empresa where Id = @Id_relacionamento  
end