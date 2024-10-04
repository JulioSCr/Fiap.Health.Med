CREATE USER fiaphealthmedusercadastro With PASSWORD 'PostgresFiapHealthMedLocalCadastro';
CREATE DATABASE cadastrofiaphealthmed;
GRANT ALL PRIVILEGES ON DATABASE cadastrofiaphealthmed TO fiaphealthmedusercadastro;
\c cadastrofiaphealthmed
GRANT ALL ON SCHEMA public TO fiaphealthmedusercadastro;