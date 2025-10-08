package sistemaAutogestion;

import java.time.LocalDate;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

public class IObligatorioTest {

    private Sistema miSistema;

    public IObligatorioTest() {
        miSistema = new Sistema();
    }

    @Before
    public void setUp() {
        miSistema = new Sistema();
        miSistema.crearSistemaDeGestion();
    }

    @Test
    public void testCrearSistemaDeGestion() {
        Retorno r = miSistema.crearSistemaDeGestion();
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testRegistrarSala() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1RegistrarSala() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 1", 120);
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2RegistrarSala() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 0);
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarSala("Sala 3", -1);
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarSala("Sala 4", -100);
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testEliminarSala() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarSala("Sala 2");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarSala("Sala 4");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarSala("Sala 1");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1EliminarSala() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarSala("Sala 6");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.eliminarSala("Sala 8");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.eliminarSala("Sala 21");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testRegistrarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV01", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1RegistrarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV01", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV01", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarEvento("EV02", "Show de stand-up", 60, LocalDate.of(2025, 4, 26));
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2RegistrarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV01", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", -70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", -100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarEvento("EV03", "Show de stand-up", 0, LocalDate.of(2025, 4, 26));
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testError3RegistrarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV01", "Torneo de E-sports", 110, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 110, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.ERROR_3, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 110, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.ERROR_3, r.resultado);
    }

    @Test
    public void testRegistrarCliente() {
        Retorno r = miSistema.registrarCliente("12567823", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("33121256", "Maria Rodriguez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("41402232", "Yuliana Suarez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1RegistrarCliente() {
        Retorno r = miSistema.registrarCliente("1256783", "Matías Oreiro");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarCliente("25645252455", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarCliente("52", "Juan Perez");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarCliente("", "Maria Rodriguez");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.registrarCliente("1", "Yuliana Suarez");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2RegistrarCliente() {
        Retorno r = miSistema.registrarCliente("12567823", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("12567823", "Maria Rodriguez");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarCliente("52326563", "Yuliana Suarez");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.registrarCliente("12345678", "Guillermo Vieira");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testComprarEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1ComprarEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("12345678", "GOD12");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.comprarEntrada("87654321", "GOD12");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.comprarEntrada("55555555", "GOD12");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2ComprarEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "EV110");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.comprarEntrada("11111111", "EV220");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD123");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testEliminarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarEvento("GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarEvento("EV03");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1EliminarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarEvento("GOD123");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.eliminarEvento("EV30");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2EliminarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eliminarEvento("GOD12");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testDevolverEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 2, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1DevolverEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 2, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("22222222", "FUT25");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2DevolverEntrada() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 2, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT26");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testCalificarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("25645252", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("52326563", "GOD12", 8, "Entretenido!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("25645252", "EV02", 7, "Bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("52326563", "EV02", 8, "Muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
    }

    @Test
    public void testError1CalificarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("22222222", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testError2CalificarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD123", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.ERROR_2, r.resultado);
    }

    @Test
    public void testError3CalificarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 100, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.ERROR_3, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", -5, "DESASTRE!");
        assertEquals(Retorno.Resultado.ERROR_3, r.resultado);
    }

    @Test
    public void testError4CalificarEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 3, "No estuvo tan bueno al final");
        assertEquals(Retorno.Resultado.ERROR_4, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 3, "No estuvo tan bueno al final");
        assertEquals(Retorno.Resultado.ERROR_4, r.resultado);
    }

    @Test
    public void testListarSalas() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 25);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 200);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        // sala-capacidad#
        r = miSistema.listarSalas();
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("Sala 3-200#Sala 2-25#Sala 1-100", r.valorString);
    }

    @Test
    public void testListarEventos() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 4", 30);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 5", 80);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("ESP01", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("PLC04", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("CHN11", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        // codigo-descripcion-sala-fecha-aforo
        r = miSistema.listarEventos();
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("CHN11-Discoteca-Sala 3-100-0#ESP01-Torneo de E-sports-Sala 5-50-0#PLC04-Película-Sala 5-70-0", r.valorString);
    }

    @Test
    public void testListarClientes() {
        Retorno r = miSistema.registrarCliente("52567823", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("57326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("33121256", "Maria Rodriguez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("41402232", "Yuliana Suarez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        // cedula-nombre
        r = miSistema.listarClientes();
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("25645252-Sebastian Pesce#33121256-Maria Rodriguez#41402232-Yuliana Suarez#52567823-Matías Oreiro#57326563-Juan Perez", r.valorString);
    }

    @Test
    public void testEsSalaOptima() {
        String[][] vistaSala = {
            {"#", "#", "#", "#", "#", "#", "#"},
            {"#", "#", "X", "X", "X", "X", "#"},
            {"#", "O", "O", "X", "X", "X", "#"},
            {"#", "O", "O", "O", "O", "X", "#"},
            {"#", "O", "O", "X", "O", "O", "#"},
            {"#", "O", "O", "O", "O", "O", "#"},
            {"#", "X", "X", "O", "O", "O", "O"},
            {"#", "X", "X", "O", "O", "O", "X"},
            {"#", "X", "X", "O", "X", "X", "#"},
            {"#", "X", "X", "O", "X", "X", "#"},
            {"#", "#", "#", "O", "#", "#", "#"},
            {"#", "#", "#", "O", "#", "#", "#"}
        };

        Retorno ret = miSistema.esSalaOptima(vistaSala);
        assertEquals(Retorno.Resultado.OK, ret.resultado);
        assertEquals("Es óptimo", ret.valorString);
    }

    @Test
    public void testNoEsSalaOptima() {
        String[][] vistaSala = {
            {"#", "#", "#", "#", "#", "#", "#"},
            {"#", "#", "X", "X", "X", "X", "#"},
            {"#", "X", "O", "X", "X", "X", "#"},
            {"#", "O", "O", "O", "O", "X", "#"},
            {"#", "X", "O", "X", "X", "O", "#"},
            {"#", "X", "X", "O", "X", "O", "#"},
            {"#", "X", "X", "X", "O", "O", "X"},
            {"#", "X", "X", "O", "O", "O", "X"},
            {"#", "X", "X", "O", "X", "X", "#"},
            {"#", "X", "X", "O", "X", "X", "#"},
            {"#", "#", "#", "X", "#", "#", "#"},
            {"#", "#", "#", "O", "#", "#", "#"}
        };

        Retorno ret = miSistema.esSalaOptima(vistaSala);
        assertEquals(Retorno.Resultado.OK, ret.resultado);
        assertEquals("No es óptimo", ret.valorString);
    }

    @Test
    public void testListarClientesDeEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.listarClientesDeEvento("GOD12", 3);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("11111111-Matías Oreiro#25645252-Sebastian Pesce#52326563-Juan Perez#", r.valorString);
    }

    @Test
    public void testListarEsperaEvento() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Bowling", 2, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("TEN22", "Partido de Tenis", 3, LocalDate.of(2025, 5, 10));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.listarEsperaEvento();
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("GOD12-52326563,11111111,25645252,52326563,#TEN22-52326563,11111111,25645252,", r.valorString);
    }

    @Test
    public void testDeshacerUtimasCompras() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Bowling", 2, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("TEN22", "Partido de Tenis", 3, LocalDate.of(2025, 5, 10));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "TEN22");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.deshacerUtimasCompras(3);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("GOD12-52326563#TEN22-11111111#TEN22-25645252#", r.valorString);
    }

    @Test
    public void testEventoMejorPuntuado() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 2", 50);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarSala("Sala 3", 120);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("GOD12", "Torneo de E-sports", 50, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV02", "Película", 70, LocalDate.of(2025, 2, 25));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("EV03", "Discoteca", 100, LocalDate.of(2025, 5, 1));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "GOD12");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("25645252", "GOD12", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("52326563", "GOD12", 8, "Entretenido!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("25645252", "EV02", 7, "Bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("52326563", "EV02", 8, "Muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("11111111", "EV03", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("25645252", "EV03", 10, "Estuvo muy bueno!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.calificarEvento("52326563", "EV03", 8, "Entretenido!");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.eventoMejorPuntuado();
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("EV03-9#GOD12-9", r.valorString);
    }

    @Test
    public void testComprasDeCliente() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 10, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprasDeCliente("11111111");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("FUT25-D#FUT25-D#FUT25-N#", r.valorString);
    }

    @Test
    public void testError1ComprasDeCliente() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 10, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprasDeCliente("98765432");
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }

    @Test
    public void testComprasXMes() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 10, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("UFC230", "Pelea de UFC", 100, LocalDate.of(2025, 1, 28));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("BD123", "Partido de badminton", 30, LocalDate.of(2025, 12, 28));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("LOL25", "Mundial de LoL", 50, LocalDate.of(2025, 1, 15));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "UFC230");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "UFC230");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "UFC230");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "BD123");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "BD123");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "LOL25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "LOL25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprasXDia(1);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        assertEquals("12-6#15-2#28-3#", r.valorString);
    }

    @Test
    public void testError1ComprasXMes() {
        Retorno r = miSistema.registrarSala("Sala 1", 100);
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarEvento("FUT25", "Partido de FIFA", 10, LocalDate.of(2025, 1, 12));
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("11111111", "Matías Oreiro");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("25645252", "Sebastian Pesce");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.registrarCliente("52326563", "Juan Perez");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("25645252", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("52326563", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprarEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.devolverEntrada("11111111", "FUT25");
        assertEquals(Retorno.Resultado.OK, r.resultado);
        r = miSistema.comprasXDia(15);
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
        r = miSistema.comprasXDia(-1);
        assertEquals(Retorno.Resultado.ERROR_1, r.resultado);
    }
}
