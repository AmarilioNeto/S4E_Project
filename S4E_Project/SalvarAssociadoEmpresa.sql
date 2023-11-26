Create procedure SalvarAssociadoEmpresa (@Cnpj nvarchar(14), @Cpf nvarchar(11))
as 
begin
declare @Id_Associado int
declare @Id_Empresa int
select @Id_Associado = Id from Associado where  Cpf = @Cpf
select @Id_Empresa = Id from Empresa where Cnpj = @Cnpj

insert into Associado_Empresa (Associado_Id, Associado_CPF, Empresa_Id, Empresa_CNPJ) values( @Id_Associado, @Cpf, @Id_Empresa, @Cnpj)
end