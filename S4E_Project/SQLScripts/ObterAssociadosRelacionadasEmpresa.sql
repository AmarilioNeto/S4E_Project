
Create Procedure ObterAssociadosRelacionadasEmpresa (@id int)  
as  
begin  
select A.Id, A.Nome, A.Cpf  
from Empresa E   
inner join Associado_Empresa AE on AE.Empresa_Id = E.Id   
inner join Associado A on A.Id = AE.Associado_Id  
where  
E.Id = @id
end
