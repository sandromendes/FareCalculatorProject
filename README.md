# FareCalculatorApp

Este projeto é um exemplo de aplicação UWP (Universal Windows Platform) utilizando a arquitetura MVVM e o framework Prism para calcular tarifas de diferentes tipos de serviços Uber, como Uber X, VIP, Black, Uber Moto, e serviços de entrega como Uber Flash e Flash Moto. O projeto também inclui o cálculo de distância entre as cidades da Região Metropolitana do Recife e tarifas baseadas em peso e dimensões da encomenda para serviços de entrega.

## Funcionalidades

- **Cálculo de tarifa:** Calcula tarifas para diferentes tipos de Uber com base em distâncias, peso e dimensões.
- **Arquitetura MVVM:** Utiliza o padrão Model-View-ViewModel (MVVM) para separar a lógica de negócios da interface do usuário.
- **Prism:** Framework para construção de aplicativos modulares e escaláveis.
- **Entrada de dados:** Usuários podem inserir informações como tipo de Uber, distância, peso e dimensões dos pacotes.

## Requisitos

- **Visual Studio 2022 ou superior**
- **Windows 10 SDK**
- **.NET Core 3.1 ou superior**

## Configuração

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/seu-usuario/FareCalculatorApp.git
   
2. **Abra o projeto no Visual Studio:**

Navegue até o diretório do projeto clonado e abra o arquivo .sln no Visual Studio.

3. **Restaurar pacotes NuGet:**

No Visual Studio, clique com o botão direito no projeto na Solution Explorer e selecione "Restaurar Pacotes NuGet".

4. **Compilar e executar:**

Compile o projeto usando **Ctrl+Shift+B** e execute-o com **F5**.

Uso

1. **Selecionar Tipo de Uber:** Use o ComboBox para selecionar o tipo de serviço Uber desejado.
2. **Inserir Informações:** Dependendo do tipo de Uber selecionado, insira a distância, peso e dimensões (se aplicável).
3. **Calcular Tarifa:** Clique no botão para calcular a tarifa e ver o resultado na tela.

## Estrutura do Projeto

1. **Views:** Contém as páginas da interface do usuário.
2. **ViewModels:** Contém as classes ViewModel que interagem com a lógica de negócios.
3. **Services:** Contém serviços como FareCalculatorService e DistanceCalculatorService para cálculos e lógica de negócios.
4. **Models:** Contém as classes de modelo que representam os dados do aplicativo.
5. **Converters:** Contém conversores de valor usados para conversão de dados entre View e ViewModel.

## Contribuição
Se você deseja contribuir para este projeto, siga estas etapas:

Faça um fork do repositório.
1. Crie uma branch para suas alterações (git checkout -b minha-feature).
2. Faça commit das suas alterações (git commit -am 'Adiciona uma nova funcionalidade').
3. Faça um push para a branch (git push origin minha-feature).
4. Envie um pull request.

## Licença
Este projeto é licenciado sob a MIT License.

## Contato
Para mais informações, entre em contato com josesandromendes@gmail.com

