package dk.via.sep3.group1.applicationlogic.networking;

import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.config.ConfigurableBeanFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.core.serializer.support.SerializationFailedException;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

@Service @Scope(value = ConfigurableBeanFactory.SCOPE_PROTOTYPE)
public class DataClientImpl implements DataClient {


    private ObjectMapper objectMapper = new ObjectMapper();


    public DataClientImpl() {
    }


    @Override
    public Reply handleRequest(Request request) {
        Socket socket;
        OutputStream outputStream = null;
        InputStream inputStream = null;
        Reply reply;
        try {
            socket = new Socket("127.0.0.1", 12345);
            inputStream = socket.getInputStream();
            outputStream = socket.getOutputStream();
            System.out.println("Client sending a request");

        } catch (IOException e) {
            e.printStackTrace();
        }
        writeBytes(request, outputStream);
        String serializedReply = readBytes(inputStream);
        reply = Serialization.deserialize(serializedReply, Reply.class);

        if (reply.getType().equals(reply.BAD_REQUEST))
        {
            String deserialize = reply.getPayload();
            throw new RuntimeException(deserialize);
        }
        return reply;
    }


    private String readBytes(InputStream inputStream) {
        byte[] readAllBytes = new byte[2048];
        try {
            readAllBytes = inputStream.readAllBytes();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return new String(readAllBytes);
    }


    private void writeBytes(Object objectToSend, OutputStream outputStream) {
        byte[] valueAsBytesTest;
        System.out.println(objectToSend);
        try {
            valueAsBytesTest = objectMapper.writeValueAsBytes(objectToSend);
            outputStream.write(valueAsBytesTest);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
