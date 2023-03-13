SET serveroutput ON
Declare
    l_SP number := '&1';
    l_Loop number := '&2';
    l_CD number;
Begin
-- supply point checkdigit
for i in 0 .. l_Loop-1 loop
select pkg_supplypoint.CheckDigit01(l_SP) into l_CD from dual;
dbms_output.put_line(to_char(l_SP)||' '||to_char(l_CD));
l_SP := l_SP + 1;
end loop;
end ;
/
EXIT;