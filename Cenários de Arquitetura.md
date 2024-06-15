## Cenários de Arquitetura

### Cenário 1: Ambos os lados têm triggers nos bancos de dados e a replicação é bilateral

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK] --> [Trigger no Banco MK]
    [Trigger no Banco MK] --> [PubSub]
}

package "NAV 2016" {
    [Banco de Dados NAV] --> [Trigger no Banco NAV]
    [Trigger no Banco NAV] --> [PubSub]
}

[PubSub] --> [Serviços de Replicação]
[Serviços de Replicação] --> [MKData]
[Serviços de Replicação] --> [NAV 2016]
@enduml
```

### Cenário 2: Apenas MKData possui trigger no banco e a replicação é bilateral

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK] --> [Trigger no Banco MK]
    [Trigger no Banco MK] --> [PubSub]
}

package "NAV 2016" {
    [Banco de Dados NAV]
}

package "Monitor de Eventos" {
    [Pooling no NAV] --> [NAV 2016]
}

[Monitor de Eventos] --> [PubSub]
[PubSub] --> [Serviços de Replicação]
[Serviços de Replicação] --> [MKData]
[Serviços de Replicação] --> [NAV 2016]
@enduml
```

### Cenário 3: Apenas NAV 2016 possui trigger no banco e a replicação é bilateral

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK]
}

package "NAV 2016" {
    [Banco de Dados NAV] --> [Trigger no Banco NAV]
    [Trigger no Banco NAV] --> [PubSub]
}

package "Monitor de Eventos" {
    [Pooling no MK] --> [MKData]
}

[Monitor de Eventos] --> [PubSub]
[PubSub] --> [Serviços de Replicação]
[Serviços de Replicação] --> [MKData]
[Serviços de Replicação] --> [NAV 2016]
@enduml
```

### Cenário 4: Nenhum dos lados possui trigger no banco e a replicação é bilateral

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK]
}

package "NAV 2016" {
    [Banco de Dados NAV]
}

package "Monitor de Eventos" {
    [Pooling no MK] --> [MKData]
    [Pooling no NAV] --> [NAV 2016]
}

[Monitor de Eventos] --> [PubSub]
[PubSub] --> [Serviços de Replicação]
[Serviços de Replicação] --> [MKData]
[Serviços de Replicação] --> [NAV 2016]
@enduml
```

### Cenário 5: Replicação somente do MK para o NAV com trigger

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados]
    [Trigger no Banco] --> [PubSub]
}

package "NAV 2016" {
    [Banco de Dados]
}

[PubSub] --> [Serviço de Replicação]
[Serviço de Replicação] --> [MKData]
@enduml
```

### Cenário 6: Replicação somente do NAV para o MK com trigger

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK]
}

package "NAV 2016" {
    [Banco de Dados NAV]
    [Trigger no Banco] --> [PubSub]
}

[PubSub] --> [Serviço de Replicação]
[Serviço de Replicação] --> [NAV 2016]
@enduml
```

### Cenário 7: Replicação somente do MK para o NAV sem trigger

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados]
}

package "Monitor de Eventos" {
    [Pooling no MK] --> [MKData]
}

package "NAV 2016" {
    [Banco de Dados]
}

[Monitor de Eventos] --> [PubSub]
[PubSub] --> [Serviço de Replicação]
[Serviço de Replicação] --> [MKData]
@enduml
```

### Cenário 8: Replicação somente do NAV para o MK sem trigger

#### Diagrama de Infraestrutura

```plantuml
@startuml
package "PubSub" {
    [Tópico de Eventos]
}

package "MKData" {
    [Banco de Dados MK]
}

package "NAV 2016" {
    [Banco de Dados NAV]
}

package "Monitor de Eventos" {
    [Pooling no NAV] --> [NAV 2016]
}

[Monitor de Eventos] --> [PubSub]
[PubSub] --> [Serviço de Replicação]
[Serviço de Replicação] --> [NAV 2016]
@enduml
```