## Requisitos de Tarifas por Tipo de Uber

### 1. UberX
- **Tarifa base**: R$ 5,00
- **Custo por quilômetro**: R$ 1,00
- **Descontos**:
  - 2 passageiros: desconto de R$ 0,50
  - Mais de 2 passageiros: desconto de R$ 1,00

### 2. UberVIP
- **Tarifa base**: R$ 10,00
- **Custo por quilômetro**: R$ 1,50
- **Descontos**:
  - 2 passageiros: desconto de R$ 0,50
  - Mais de 2 passageiros: desconto de R$ 1,00

### 3. UberBlack
- **Tarifa base**: R$ 15,00
- **Custo por quilômetro**: R$ 2,00
- **Descontos**:
  - 2 passageiros: desconto de R$ 1,00
  - Mais de 2 passageiros: desconto de R$ 2,00

### 4. UberMoto
- **Tarifa base**: R$ 3,00
- **Custo por quilômetro**: R$ 0,75

### 5. FlashMoto
- **Tarifa base**: R$ 4,00
- **Custo por quilômetro**: R$ 1,00
- **Aumento de tarifa**:
  - Pacotes acima de 20 kg ou dimensão maior que 1 m³: custo por km aumenta para R$ 1,50

### 6. UberFlash
- **Tarifa base**: R$ 8,00
- **Custo por quilômetro**: R$ 2,00
- **Aumento de tarifa**:
  - Pacotes acima de 10 kg: custo por km aumenta para R$ 1,00
  - Pacotes maiores que 1 m³: custo por km aumenta para R$ 1,50

---

## Cenários BDD

### UberX

#### Cenário: Cálculo da tarifa do UberX com 1 passageiro
- **Dado** que o veículo é um UberX com 1 passageiro
- **Quando** a distância percorrida é de 10 km
- **Então** a tarifa total deve ser R$ 15,00

#### Cenário: Cálculo da tarifa do UberX com 2 passageiros
- **Dado** que o veículo é um UberX com 2 passageiros
- **Quando** a distância percorrida é de 10 km
- **Então** a tarifa total deve ser R$ 14,50

#### Cenário: Cálculo da tarifa do UberX com mais de 2 passageiros
- **Dado** que o veículo é um UberX com 3 passageiros
- **Quando** a distância percorrida é de 10 km
- **Então** a tarifa total deve ser R$ 14,00

---

### UberVIP

#### Cenário: Cálculo da tarifa do UberVIP com 1 passageiro
- **Dado** que o veículo é um UberVIP com 1 passageiro
- **Quando** a distância percorrida é de 20 km
- **Então** a tarifa total deve ser R$ 40,00

#### Cenário: Cálculo da tarifa do UberVIP com 2 passageiros
- **Dado** que o veículo é um UberVIP com 2 passageiros
- **Quando** a distância percorrida é de 20 km
- **Então** a tarifa total deve ser R$ 39,50

---

### UberBlack

#### Cenário: Cálculo da tarifa do UberBlack com 1 passageiro
- **Dado** que o veículo é um UberBlack com 1 passageiro
- **Quando** a distância percorrida é de 5 km
- **Então** a tarifa total deve ser R$ 25,00

#### Cenário: Cálculo da tarifa do UberBlack com 3 passageiros
- **Dado** que o veículo é um UberBlack com 3 passageiros
- **Quando** a distância percorrida é de 5 km
- **Então** a tarifa total deve ser R$ 23,00

---

### UberMoto

#### Cenário: Cálculo da tarifa do UberMoto
- **Dado** que o veículo é um UberMoto
- **Quando** a distância percorrida é de 8 km
- **Então** a tarifa total deve ser R$ 9,00

---

### FlashMoto

#### Cenário: Cálculo da tarifa do FlashMoto para pacotes leves
- **Dado** que o veículo é um FlashMoto com pacote de 15 kg
- **Quando** a distância percorrida é de 10 km
- **Então** a tarifa total deve ser R$ 14,00

#### Cenário: Cálculo da tarifa do FlashMoto para pacotes pesados
- **Dado** que o veículo é um FlashMoto com pacote de 25 kg
- **Quando** a distância percorrida é de 10 km
- **Então** a tarifa total deve ser R$ 19,00

---

### UberFlash

#### Cenário: Cálculo da tarifa do UberFlash para pacote de 8 kg
- **Dado** que o veículo é um UberFlash com pacote de 8 kg e dimensão de 0.8 m³
- **Quando** a distância percorrida é de 15 km
- **Então** a tarifa total deve ser R$ 38,00

#### Cenário: Cálculo da tarifa do UberFlash para pacotes volumosos
- **Dado** que o veículo é um UberFlash com pacote de 12 kg e dimensão de 1.2 m³
- **Quando** a distância percorrida é de 15 km
- **Então** a tarifa total deve ser R$ 45,00

---

### Exemplo 1: Cálculo de tarifa para UberX

Tipo de veículo: UberX
Passageiros: 2
Distância: 15 km

**Fórmula:**
A tarifa base para o UberX é de 5,00 e a taxa por quilômetro é de 1,00. No caso de 2 passageiros, subtrai-se 0,50 da tarifa base.

**Cálculo:**
- Tarifa = Tarifa Base - 0,50 + (Custo por KM * Distância)
- Tarifa = 5.00 - 0.50 + (1.00 * 15)
- Tarifa = 4.50 + 15.00
- Tarifa = 19.50

Resultado: A tarifa para o UberX com 2 passageiros e 15 km de distância é 19,50.

### Exemplo 2: Cálculo de tarifa para FlashMoto

Tipo de veículo: FlashMoto
Peso: 15 kg
Distância: 8 km

**Fórmula:**
A tarifa base para o FlashMoto é de 4,00. Para pesos maiores que 10 kg, a taxa por quilômetro é 1,00.

Tarifa = Tarifa Base + (Custo por KM * Distância)

**Cálculo:**
- Tarifa = 4.00 + (1.00 * 8)
- Tarifa = 4.00 + 8.00
- Tarifa = 12.00

Resultado: A tarifa para o FlashMoto com 15 kg de peso e 8 km de distância é 12,00.


