pipeline {
  agent any
  triggers {
        cron('H 5 * * *')
    }
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/NicolasGhersiVDQ/TestsVIP.git', branch: 'master')
      }
    }
    stage('Build') {
      steps {
        bat "\"${tool 'MSBuild'}\" VIP.sln /t:Restore /p:Configuration=Debug /p:Platform=\"Any CPU\""
      }
    }
    stage('Tests') {
      steps {
        bat "\"${tool 'NUnit'}\" .\\VIP\\bin\\Debug\\VIP.dll"
      }
    }
    stage('Report') {
      steps {
        nunit(testResultsPattern: 'TestResult.xml', failIfNoResults: true, keepJUnitReports: true)
      }
    }
    stage('Monitor') {
      steps {
        bat '.\\VIP\\bin\\Debug\\TestResultReader.exe'
      }
    }
  }
}