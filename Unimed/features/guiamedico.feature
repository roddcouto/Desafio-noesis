Feature: Pesquisar médicos do Rio de Janeiro

   Pacientes desejam pesquisar médicos do Rio de Janeiro através do guia médico da Unimed.

   Scenario: Acesso ao guia médico
      Given  O paciente acessa o guia médico da unimed
      When O paciente pesquisa pela cidade do Rio de Janeiro
      Then Os resultados dos médicos do Rio de Janeiro são apresentados

   Scenario: Acesso ao guia médico sem apresentar resultados de São Paulo
      Given O paciente realiza o acesso guia médico da Unimed
      When O paciente faz a pesuisa pela cidade do Rio de Janeiro
      And Escolhe a unidade unimed disponível
      Then Os resultados dos médicos do Rio de Janeiro são visualizados
      And Os resultados nas páginas um, dois e três não apresentam resultados de São Paulo