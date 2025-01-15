# EndpointManager

## Sobre o Projeto

O **EndpointManager** é uma aplicação console desenvolvida em .NET para gerenciar endpoints de uma empresa de energia. Este projeto foi criado como um exercício de programação para demonstrar habilidades em design de software, validação de entradas, separação de lógica de negócios e interface, além do uso de padrões de programação modernos.

## Funcionalidades

A aplicação permite:

1. **Inserir um novo endpoint:**
   - O usuário fornece todos os atributos do endpoint.
   - Caso o "Endpoint Serial Number" já exista, é exibida uma mensagem de erro e o endpoint não é criado.

2. **Editar um endpoint existente:**
   - O usuário fornece o "Endpoint Serial Number".
   - Permite alterar apenas o estado do "Switch State".

3. **Excluir um endpoint existente:**
   - O usuário fornece o "Endpoint Serial Number".
   - Solicita confirmação antes de excluir.

4. **Listar todos os endpoints:**
   - Exibe na tela os detalhes de todos os endpoints registrados.

5. **Encontrar um endpoint pelo "Endpoint Serial Number":**
   - Exibe os detalhes do endpoint correspondente ou uma mensagem de erro caso não encontrado.

6. **Sair da aplicação:**
   - Solicita confirmação antes de fechar.

## Estrutura dos Endpoints

Cada endpoint contém os seguintes atributos:

- **Endpoint Serial Number:** String.
- **Meter Model ID:** Integer.
  - NSX1P2W: 16.
  - NSX1P3W: 17.
  - NSX2P3W: 18.
  - NSX3P4W: 19.
- **Meter Number:** Integer.
- **Meter Firmware Version:** String.
- **Switch State:** Integer.
  - Desconectado: 0.
  - Conectado: 1.
  - Armado: 2.

## Requisitos

- **.NET Framework:** 4.6 ou superior.
- **Banco de Dados:** Não utilizado (os endpoints são armazenados em memória).

## Instruções de Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/GBMellow/EndpointManager.git
   cd EndpointManager
   ```

2. Abra o projeto no Visual Studio ou em um editor compatível com .NET.

3. Compile e execute a aplicação.

4. Siga as instruções no console para interagir com o sistema.

## Testes

- O projeto inclui pelo menos 4 testes unitários com dados mockados para validar a lógica de negócios.
- As classes de interface com o usuário não requerem testes unitários.

## Padrões e Tecnologias Utilizadas

- **Interface e Herança:** Utilizadas para garantir a flexibilidade do design.
- **Expressões Lambda e Consultas LINQ:** Para processamento eficiente de coleções.
- **Exceções:** Para tratamento de erros.
- **Validação de Entrada:** Para garantir a consistência dos dados fornecidos.
- **Encapsulamento:** Uso adequado de modificadores de acesso (público, interno, privado ou protegido).

## Contato

Gabriel Bellanda Mello  
E-mail: gabrielb1191@hotmail.com  
LinkedIn: [linkedin.com/in/gabrielbellandamello](https://www.linkedin.com/in/gabrielbellandamello)

---

Este projeto foi desenvolvido como parte de um exercício para um processo seletivo e demonstra boas práticas de programação e design de software.

