pipeline {
    agent any
    stages {
        stage("Compilar") {
            steps {
                sh "dotnet build"
            }
        }
        stage("Tests unitaris") {
            steps {
                sh "dotnet test VaquesBackendTests/"
            }
        }
        stage("Tests UI") {
            when { branch "main"}
            stages {
                stage("Iniciar el sistema") {
                    steps {
                        sh "docker-compose -d"
                    }
                }
                stage("Executa tests UI") {
                    steps {
                        sh "dotnet test vaquesUiTest/"
                    }
                }
            }
            post {
                always {
                    sh "docker-compose down"
                }
            }
        }

    }
}