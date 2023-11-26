
Create Procedure ObterEmpresaRelacionadasAssociado (@id int)
as
begin
select E.Id, E.Nome, E.Cnpj
from Empresa E 
inner join Associado_Empresa AE on AE.Empresa_Id = E.Id 
inner join Associado A on A.Id = AE.Associado_Id
where
a.Id = @id
end