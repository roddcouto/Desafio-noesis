Feature: Pesquisar médicos do Rio de Janeiro

   Pacientes desejam pesquisar médicos do Rio de Janeiro através do guia médico da Unimed.

   Scenario: Acesso ao guia médico
    Given  O paciente acessa o guia médico da unimed
    When O paciente pesquisa pela cidade do Rio de Janeiro
    Then Os resultados dos médicos do Rio de Janeiro são apresentados