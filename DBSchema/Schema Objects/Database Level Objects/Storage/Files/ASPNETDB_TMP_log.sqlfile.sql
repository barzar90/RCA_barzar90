ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [ASPNETDB_TMP_log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_Log.ldf', FILEGROWTH = 10 %);

